using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : CharacterManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    EnemyAnimatorManager enemyAnimatorManager;
    EnemyStats enemyStats;
    

    public bool isPreformingAction;
    public bool isInteracting;

    public NavMeshAgent navMeshAgent;
    public State currentState;
    public CharacterStats currentTarget;

    public Rigidbody enemyRigidBody;

    public float distanceFromTarget;
    public float rotationSpeed = 25;
    public float maximumAttackRange = 2.5f;



    [Header("A.I. Settings")]
    public float detectionRadius = 10;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float viewableAngle;


    public float currentRecoveryTime = 0;
    private void Awake() 
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        enemyStats = GetComponent<EnemyStats>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        navMeshAgent.enabled = false;
        enemyRigidBody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        enemyRigidBody.isKinematic = false;
    }
    private void Update() 
    {
        HandleRecoveryTimer();
       // isInteracting = enemyAnimatorManager.anim.GetBool("IsInteracting");
    }
    private void FixedUpdate() 
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        if (currentState != null)
        {
            State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);

            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }

    private void SwitchToNextState(State state)
    {
        currentState = state;
    }

    private void HandleRecoveryTimer()
    {
        if (currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (isPreformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPreformingAction = false;
            }
        }
    }
    
}
