using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : CharacterManager
{
    [HideInInspector]EnemyLocomotionManager enemyLocomotionManager;
    [HideInInspector] EnemyAnimatorManager enemyAnimatorManager;
    [HideInInspector] EnemyStats enemyStats;

    public State currentState;
    public CharacterStats currentTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Rigidbody enemyRigidBody;

    public bool isPreformingAction;
    public bool isInteracting;
    public float rotationSpeed = 25;
    public float maximumAttackRange = 2.5f;
    [HideInInspector]public float distanceFromTarget;

    [Header("Combat Flags")]
    public bool canDoCombo;
    
    [Header("A.I. Settings")]
    public float detectionRadius = 10;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    [HideInInspector]public float viewableAngle;
    public float currentRecoveryTime = 0;
    [Header("A.I. Combat Settings")]
    public bool allowAIPerformCombos;
    public float comboLikelyHood;
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
        HandleStateMachine();

        //isInteracting = enemyAnimatorManager.anim.GetBool("IsInteracting");
        canDoCombo = enemyAnimatorManager.anim.GetBool("canDoCombo");
        canRotate = enemyAnimatorManager.anim.GetBool("canRotate");
        enemyAnimatorManager.anim.SetBool("isDead", enemyStats.isDead);
    }
    private void LateUpdate()
    {
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;
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
            if (currentRecoveryTime <= 0)
            {
                isPreformingAction = false;
            }
        }
    }
}
