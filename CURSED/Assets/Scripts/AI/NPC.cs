using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [Header("Initial Parameters")]
    public float lookRadius = 10f;
    public State WaitState;
    public State AttackState;
    public State StartState;

    [Header("Actual state")]
    public State CurrentState; 


    [HideInInspector]public Vector3 startPosition;
    [HideInInspector]public Transform target;
    NavMeshAgent agent;
    
    void Start()
    {
        startPosition = transform.position;
        // target = GameObject.FindGameObjectWithTag("Player").transform;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        CurrentState = WaitState;
        SetState(StartState);
    }

     
    void Update()
    {
        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        //дорого - заменить
        float distance = Vector3.Distance(target.position,transform.position);

        if (distance <= lookRadius)
        {
            SetState(AttackState);
        }
        else
        {
            SetState(WaitState);
        }
    }

    public void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.NPC = this;
        CurrentState.Init();
    }

    public void SelectDestination(Vector3 pos)
    {
        agent.SetDestination(pos);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
