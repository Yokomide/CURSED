using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    public bool isPreformingAction;
    [Header("A.I. Settings")]
    public float detectionRadius = 10;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    private void Awake() 
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }
    private void Update() 
    {
        
    }
    private void FixedUpdate() 
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if(enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
    }
}
