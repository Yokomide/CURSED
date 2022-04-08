using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public RotateTowardsTargetState rotateTowardsTargetState;
    public CombatStanceState combatStanceState;
    public PursueTargetState pursueTargetState;
    public EnemyAttackAction currentAttack;
    public bool willDoComboOnNextAttack = false;
    public bool hasPerformedAttack = false;


    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        RotateTowardsTargetWhilstAttacking(enemyManager);   
        
        if(enemyManager.distanceFromTarget > enemyManager.maximumAttackRange)
        {
            return pursueTargetState;
        }
        if (willDoComboOnNextAttack &&enemyManager.canDoCombo)
        {

        }
        if(!hasPerformedAttack)
        {
            AttackTarget(enemyAnimatorManager,enemyManager);
            RollForComboChance(enemyManager); 
        }
        if(willDoComboOnNextAttack && hasPerformedAttack)
        {
            return this;
        }
        return rotateTowardsTargetState;
        
    }
    private void RotateTowardsTargetWhilstAttacking(EnemyManager enemyManager)
    {
        if (enemyManager.canRotate && enemyManager.isInteracting)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position = transform.position;
            direction.y = 0;
            direction.Normalize();
            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
    }
    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager,EnemyManager enemyManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation,true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
        currentAttack = null;
    }
    private void AttackTargetWithCombo(EnemyAnimatorManager enemyAnimatorManager ,EnemyManager enemyManager)
    {
        willDoComboOnNextAttack = false;
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation,true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        currentAttack = null;
    }
    private void RollForComboChance(EnemyManager enemyManager)
    {
        float comboChance = Random.Range(0,100);

        if(enemyManager.allowAIPerformCombos && comboChance <= enemyManager.comboLikelyHood)
        {
            if(currentAttack.comboAction != null)
            {
                willDoComboOnNextAttack = true;
                currentAttack = currentAttack.comboAction;
            }
            else
            {
                willDoComboOnNextAttack = false;
                currentAttack = null;
            }
        }
    }
}
