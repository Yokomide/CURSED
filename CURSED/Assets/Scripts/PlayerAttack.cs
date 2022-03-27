using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainHero
{ 
public class PlayerAttack : MonoBehaviour
{
    public ThirdPersonController controller;

    private void Start()
    {
        controller = GetComponent<ThirdPersonController>();

       // GameEvents.current.onAttackStart += Attack;
    }
    private void Awake()
    {

    }

    public void HandleLightAttack(WeaponItem weapon)
    {
            controller.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
            controller.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
    }
}
}
