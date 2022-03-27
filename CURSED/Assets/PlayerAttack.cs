using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    private int _animIDAttack;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _animIDAttack = Animator.StringToHash("Attack");

        GameEvents.current.onAttackStart += Attack;
    }
    private void Awake()
    {
        
    }
    private void Attack()
    {
        anim.SetBool(_animIDAttack, true);
    }
    public void HandleLightAttack(WeaponItem weapon)
    {

    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {

    }
}
