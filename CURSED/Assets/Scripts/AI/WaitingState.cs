using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]

public class WaitingState : State
{
    public override void Init() { }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (Vector3.Distance(NPC.target.position, NPC.transform.position) <= NPC.lookRadius)
        {
            IsFinished = true;
        }
        NPC.SelectDestination(NPC.startPosition);
    }
}