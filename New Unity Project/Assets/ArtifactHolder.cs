using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGM.Gameplay
{

public class ArtifactHolder : MonoBehaviour
{

    public bool isTriggered = false;
    public string id;
    public GameObject objectToSpawn;

    private void OnTriggerEnter2D(Collider2D other){

        //if Boulder collided with boulder
        if(other.CompareTag("Player") /*&& PlayerPrefs.GetInt(id) == 1*/){
            Debug.Log("enter trigger");
            isTriggered = true;
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }

/*
    private void OnTriggerExit2D(Collider2D other){
        //Debug.Log(other.tag);

        //if Player collided with boulder
        if(other.CompareTag("Player")){
            Debug.Log("exit trigger");
            isTriggered = false;
        }
    }
*/
}
}
