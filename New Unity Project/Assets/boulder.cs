using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGM.Gameplay{
public class boulder : MonoBehaviour
{

    //test
    public GameObject player_1;
    private CharacterController2D script;


    private void OnTriggerEnter2D(Collider2D other){
        //Debug.Log(other.tag);

        //if Player collided with boulder
        if(other.CompareTag("Player")){
            //Debug.Log("enter trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        //Debug.Log(other.tag);

        //if Player collided with boulder
        if(other.CompareTag("Player") && isMooving()){ //if player pushed the boulder
            //Debug.Log("exit trigger");
        }
    }

    public float speed = 0.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);

        //test
        player_1 = GameObject.Find("Character");
        script = player_1.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //test
        if(script.nextMoveCommand != Vector3.zero){
            //Debug.Log("hallo!");
        }
        

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

        //Debug.Log(rb.velocity);   
    }

    private bool isMooving(){
        return(rb.velocity.x != 0 || rb.velocity.y != 0);
    }
}
}
