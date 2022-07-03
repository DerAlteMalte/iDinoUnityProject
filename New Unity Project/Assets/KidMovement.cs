using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGM.Gameplay
{

public class KidMovement : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;
    public int positionIndex = 0; //0 = is moving to target (everything else means standing still at specific position)
    public bool isMoving = false;

    void Start(){
        //test
        //target = Waypoints.points[0];
    }

    void Update(){
        if(isMoving)      
            moveTo(positionIndex);  //test
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
    /*
    public void moveTo(int id){
        id = id - 1; //because we're starting to count at 1
        positionIndex = 0;
        target = ((GameObject)Waypoints.points[id]).GetComponent<Transform>(); //old test: ((GameObject)Waypoints.points[0]).GetComponent<Transform>();
        Vector2 dir = target.position - transform.position;

        if(!(Vector2.Distance(transform.position, target.position) < 0.1f)){              //if player has not reached Position yet, move him in dir of target position
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        } else {                                                                        //else set positionIndex to id of new waypoint he's at now
            positionIndex = id;
            //Debug.Log("at new waypoint");
        }
    }
    */
}
}
