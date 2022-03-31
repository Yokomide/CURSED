using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{
    public bool isSleeping;
    public float detectionRadius = 2;
    public string sleepAnimation;
    public string wakeAnimation;
    public PursueTargetState pursueTargetState;

    public LayerMask detectionLayer;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (isSleeping && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimation(sleepAnimation, true);
        }

        #region Handle Target Detection
        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if (characterStats != null)
            {
                Vector3 targetsDirection = characterStats.transform.position - enemyManager.transform.position;
                enemyManager.viewableAngle = Vector3.Angle(targetsDirection, enemyManager.transform.forward);

                if (enemyManager.viewableAngle > enemyManager.minimumDetectionAngle && enemyManager.viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    enemyManager.currentTarget = characterStats;
                    isSleeping = false;
                    enemyAnimatorManager.PlayTargetAnimation(wakeAnimation, true);
                }
            }
        }
        #endregion

        #region Handle State Change
        if (enemyManager.currentTarget != null)
        {
            return pursueTargetState;
        }
        else
        {
            return this;
        }
        #endregion
    }

}
