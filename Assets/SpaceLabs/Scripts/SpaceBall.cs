using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBall : MonoBehaviour
{
    private SpaceGameManager umpireInstance;

    private void Start()
    {
        umpireInstance = SpaceGameManager.GetInstance();    
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "enemy":
                umpireInstance.bstate = SpaceGameManager.BallState.AtEnemy;
                this.transform.SetParent(other.gameObject.transform);
                break;
            case "Player":
                umpireInstance.bstate = SpaceGameManager.BallState.AtPlayer;
                this.transform.SetParent(other.gameObject.transform);
                break;
            default:
                umpireInstance.bstate = SpaceGameManager.BallState.AtRest;
                break;
        }
    }
}
