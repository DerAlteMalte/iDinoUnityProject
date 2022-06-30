using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGM.Gameplay
{

public class BoulderPlate : MonoBehaviour
{

    public bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other){

        //if Boulder collided with boulder
        if(other.CompareTag("Boulder")){
            Debug.Log("enter trigger");
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        //Debug.Log(other.tag);

        //if Player collided with boulder
        if(other.CompareTag("Boulder")){
            Debug.Log("exit trigger");
            isTriggered = false;
        }
    }
}
}
