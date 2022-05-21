using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeGoal : MonoBehaviour
{
    private SpaceGameManager umpireInstance;

    private void Start()
    {
        umpireInstance = SpaceGameManager.GetInstance();    
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "enemy"){
            other.transform.Find("Space Ball").parent = null;

            umpireInstance.bstate = SpaceGameManager.BallState.AtHome;
            
        }
    }
}
