using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AttackState : State
{
    public override void Init() { }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }

        if (Vector3.Distance(NPC.target.position, NPC.transform.position) > NPC.lookRadius)
        {
            IsFinished = true;
        }
        NPC.SelectDestination(NPC.target.position);

    }
}
