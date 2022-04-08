using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTargetState : State
{
    public CombatStanceState combatStanceState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyAnimatorManager.anim.SetFloat("Vertical",0);
        enemyAnimatorManager.anim.SetFloat("Horizontal",0);

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float viewableAngle = Vector3.SignedAngle(targetDirection,enemyManager.transform.forward,Vector3.up);

        // if(viewableAngle >= 100 && viewableAngle <= 180 && !enemyManager.isInteracting)
        // {
        //     enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Behind",true);
        //     return this;
        // }
        // else if(viewableAngle <= -101 && viewableAngle >= -180 && !enemyManager.isInteracting)
        // {
        //     enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Behind",true);
        //     return this;
        // }
        // else if(viewableAngle <= -45 && viewableAngle >= -100 && !enemyManager.isInteracting)
        // {
        //     enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Right",true);
        //     return this;
        // }
        // else if(viewableAngle >= 45 && viewableAngle <= 100 && !enemyManager.isInteracting)
        // {
        //     enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Left",true);
        //     return this;
        // }

        return combatStanceState;
    }
}
