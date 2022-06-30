using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{

public class iDinoCharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;
    private bool ice;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();  
        speed = 3f;   
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        if(!ice || (Math.Abs(rb.velocity.x) == 0 && Math.Abs(rb.velocity.y) == 0)){ //wenn man nicht auf eis steht, oder auf eis steht, aber still
            //Debug.Log("movement active");
            if(Math.Abs(moveHorizontal) > 0.01){
                rb.velocity = new Vector2(moveHorizontal * speed, 0f);
            }
            else if(Math.Abs(moveVertical) > 0.01){
                rb.velocity = new Vector2(0f, moveVertical * speed);
            }
            else{
                rb.velocity = Vector2.zero;
            }
        }
        else{
            //Debug.Log("no movement!!");
            //...
        }
        adjustDirectionalSpeed();
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
