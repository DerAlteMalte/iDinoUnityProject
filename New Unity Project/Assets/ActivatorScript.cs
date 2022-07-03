using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGM.Gameplay
{

public class ActivatorScript : MonoBehaviour
{

    public int waypointId;
    public GameObject kid;
    private KidMovement kidMovement;
    //public int dir; // 0 = north, 1 = east, 2 = south, 3 = west

    void Awake(){
        kid = GameObject.Find("Kid");
        kidMovement = kid.GetComponent<KidMovement>();
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player") && !kidMovement.isMoving){
            kidMovement.moveTo(waypointId);
        }
    }

    void OnTriggerExit2D(Collider2D other){}

}
}
