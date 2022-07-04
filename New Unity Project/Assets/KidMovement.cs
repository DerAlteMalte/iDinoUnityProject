using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGM.Gameplay
{

public class KidMovement : MonoBehaviour
{
    public float speed;

    private Transform target;
    public int positionIndex = 0; //current position of NPC
    public bool isMoving = false;

    void Update(){
        if(isMoving){   
            moveTo(positionIndex);
        }
    }

    //tell NPC to move to a Waypoint with specific index
    public void moveTo(int id){
        isMoving = true;
        positionIndex = id;
        target = ((GameObject)Waypoints.points[id]).GetComponent<Transform>(); //old test: ((GameObject)Waypoints.points[0]).GetComponent<Transform>();
        Vector2 dir = target.position - transform.position;

        if(!(Vector2.Distance(transform.position, target.position) < 0.1f)){              //if player has not reached Position yet, move him in dir of target position
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        } else {                                                                        //else set positionIndex to id of new waypoint he's at now
            isMoving = false;
            Debug.Log("at new waypoint");
            return;
        }
    }
}
}
