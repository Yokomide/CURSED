using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MainHero
{
    public class PlayerAttack : MonoBehaviour
    {
       [HideInInspector] public AnimatorManager animController;
       [HideInInspector] public ThirdPersonController controller;

        public string lastAttack;
        public bool comboFlag;

        private PlayerStats playerStats;
        private PlayerInventory playerInventory;

        public GameObject skill;
        public Button SpellButton;

        private void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            controller = GetComponent<ThirdPersonController>();
            animController = GetComponent<AnimatorManager>();
            playerInventory = GetComponent<PlayerInventory>();
        }

        public void WeaponCombo(WeaponItem weapon)
        {
            if (comboFlag)
            {
                animController.anim.SetBool("canDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {

                 //   playerStats.StaminaWaste(20);
                    animController.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                   lastAttack = weapon.OH_Light_Attack_2;

                }
                else if (lastAttack == weapon.OH_Light_Attack_2)
                {
                 //   playerStats.StaminaWaste(30);
                    animController.PlayTargetAnimation(weapon.OH_Light_Attack_3, true);
                }

            }
        }

        public void SpellButtonPressed()
        {
            if (playerStats.currentStamina < 30) return;

            else
            {
                animController.PlayTargetAnimation("CastSpell", true);
            }       
        }
        public void CastSpell()
        {
            if (playerStats.currentMana < 20) return;
            {
                Instantiate(skill, transform.position, transform.rotation);
                SpellButton.interactable = false;
                StartCoroutine(CoolDown());
            }
        }
        IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(6f);
            SpellButton.interactable = true;  
        }
        public void LightAttackButtonPressed()
        {
            if (playerStats.currentStamina < 20) return;
            else
            {
                if (controller.canDoCombo)
                {
                    comboFlag = true;
                    WeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (controller.isInteracting)
                    {
                        return;
                    }
                    if (controller.canDoCombo)
                        return;
                    HandleLightAttack(playerInventory.rightWeapon);
                }
            }
        }
        public void HeavyAttackButtonPressed()
        {
            //if (controller.canDoCombo)
            //{
            //    comboFlag = true;
            //    WeaponCombo(playerInventory.rightWeapon);
            //    comboFlag = false;
            //}
            if (playerStats.currentStamina < 30) return;
            else
            {
                if (controller.isInteracting)
                {
                    return;
                }
                if (controller.canDoCombo)
                    return;
                HandleHeavyAttack(playerInventory.rightWeapon);
            }
            
        }
        public void HandleLightAttack(WeaponItem weapon)
    {
           // playerStats.StaminaWaste(20);
            animController.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
            lastAttack = weapon.OH_Light_Attack_1;
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
           // playerStats.StaminaWaste(30);
            animController.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            lastAttack = weapon.OH_Heavy_Attack_1;
        }
}
}
