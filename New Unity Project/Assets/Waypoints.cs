using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGM.Gameplay
{

public class Waypoints : MonoBehaviour
{
   public static ArrayList points = new ArrayList();
   public GameObject[] wps;
   public static ArrayList scripts = new ArrayList();

    void Awake(){
        //get all Waypoints that are child of Waypoitns Object
        wps = GameObject.FindGameObjectsWithTag("Waypoint");
        Debug.Log(wps.Length);

        //fill scripts ArrayList with GameObjects sorted by id
        foreach(GameObject o in wps){
            for(int i = 0; i < wps.Length; i++){
                WaypointScript s = o.GetComponent<WaypointScript>();
                if(s.id == i){
                    points.Add( o );
                    scripts.Add(s);
                }
            }
        }
    }
}
}
