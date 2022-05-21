using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float acceleration;
    private GameObject playerShip;
    private GameObject spaceBall;
    private GameObject homeGoal;
    private Rigidbody _rb;
    private Vector3 direction;
    private SpaceGameManager umpireInstance;

    private void Start()
    {
        // Instantiate cached variables    
        _rb = this.GetComponentInChildren<Rigidbody>();
        playerShip = GameObject.FindGameObjectWithTag("Player");
        spaceBall = GameObject.FindGameObjectWithTag("spaceball");
        homeGoal = GameObject.FindGameObjectWithTag("enemyHG");
        umpireInstance = SpaceGameManager.GetInstance();
    }

    private void Update()
    {
        switch (umpireInstance.bstate)
        {
            case SpaceGameManager.BallState.AtRest:
                SeekSpaceBall();
                break;
            case SpaceGameManager.BallState.AtPlayer:
                SeekPlayerShip();
                break;
            case SpaceGameManager.BallState.AtEnemy:
                SeekHomeGoal();
                break;
        }
    }

    #region Seeking functions
    void SeekPlayerShip()
    {
        // Add code here

    }

    void SeekSpaceBall()
    {  
        // Add code here

        // Calculate the direction to the space ball
        // Rotate towards the direction of the space ball
        // Move towards the position of the space ball
        
    }

    void SeekHomeGoal()
    {
        // Add code here
        direction = homeGoal.transform.position - transform.position;

    }
    #endregion

}
