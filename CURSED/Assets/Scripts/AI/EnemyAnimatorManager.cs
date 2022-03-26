using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }

    private void OnAnimatorMove() 
    {
        float delta = Time.deltaTime;
        enemyLocomotionManager.enemyRigidBody.drag = 0;
        Vector3 deltaPosition = anim.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition/ delta;
        enemyLocomotionManager.enemyRigidBody.velocity = velocity;
    }
}
