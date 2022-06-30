using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple controller for animating a 4 directional sprite using Physics.
    /// </summary>
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        public Animator animator;
        public bool flipX = false;
        //Ice
        private Rigidbody2D rb;
        private float moveHorizontal;
        private float moveVertical;
        private float ice_speed;
        private bool ice;
        /*
        public int iceCrossing = 0;
        public Vector3 lastMoveCommand;
        public bool ice = false;
        private Rigidbody2D rb;
        private bool ice_debug = false;
        */

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        enum State
        {
            Idle, Moving
        }

        State state = State.Idle;
        Vector3 start, end;
        Vector2 currentVelocity;
        float startTime;
        float distance;
        float velocity;

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                start = transform.position;
                end = start + nextMoveCommand;
                distance = (end - start).magnitude;
                velocity = 0;
                UpdateAnimator(nextMoveCommand);
                nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            if (!ice)
            {
                velocity = Mathf.Clamp01(velocity + Time.deltaTime * acceleration);
                UpdateAnimator(nextMoveCommand);
                rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
                spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
            }

            else
            {
                //rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, lastMoveCommand * speed, ref currentVelocity, acceleration, speed);                
            }
        }

        void UpdateAnimator(Vector3 direction)
        {
            
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
                    
            }
            
        }

        void Update()
        {

            //test
            //PlayerPrefs.SetInt("0", 0);
            //Debug.Log(PlayerPrefs.GetInt("3"));

            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }

            //ice movement
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            if(ice && (Math.Abs(rb.velocity.x) == 0 && Math.Abs(rb.velocity.y) == 0)){
                //Debug.Log("movement active");
                if(Math.Abs(moveHorizontal) > 0.01){
                    rb.velocity = new Vector2(moveHorizontal * ice_speed, 0f);
                }
                else if(Math.Abs(moveVertical) > 0.01){
                    rb.velocity = new Vector2(0f, moveVertical * ice_speed);
                }
                else{
                    rb.velocity = Vector2.zero;
                }
                UpdateAnimator(rb.velocity);
                adjustDirectionalSpeed();
            }  

        }

        void LateUpdate()
        {
            if (pixelPerfectCamera != null)
            {
                transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
            }
        }

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
            rb = this.GetComponent<Rigidbody2D>();

            //ice
            rb = gameObject.GetComponent<Rigidbody2D>();  
            ice_speed = 3f;  
            ice = false;
        }

        void FixedUpdate(){
                     
        }

        private void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Ice")){
                ice = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other){
            if (other.CompareTag("Ice")){
                ice = false;
            }
        }

        private bool isMooving(){
            return(rb.velocity.x != 0 || rb.velocity.y != 0);
        }

        private void adjustDirectionalSpeed(){
            if(isMooving()){

                //check for exidental movement
                if(Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y) < 0.5){
                    rb.velocity = Vector2.zero;
                }

                //sets x or y value to zero, so the boulder only moves directly in one compass direction
                if(Math.Abs(rb.velocity.x) > Math.Abs(rb.velocity.y)){
                    rb.velocity = new Vector2(rb.velocity.x, 0);    
                } 
                else if(Math.Abs(rb.velocity.x) < Math.Abs(rb.velocity.y)){
                    rb.velocity = new Vector2(0, rb.velocity.y); 
                }
            }
        }
    }
}