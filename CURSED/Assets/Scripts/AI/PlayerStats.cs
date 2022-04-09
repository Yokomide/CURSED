using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainHero
{
    public class PlayerStats : CharacterStats
    {
        
        public HealthBar healthBar;
        public StaminaBar staminaBar;
        public AnimatorManager animController;

        public float staminaRegenerationAmount = 30;
        public float staminaRegenTimer = 0;

        [SerializeField]
        private GameManager _gameManager;

        private ThirdPersonController _controller;
        public bool isDead;
        void Start()
        {
            _controller = GetComponent<ThirdPersonController>();
            animController = GetComponent<AnimatorManager>();
            maxHealth = SetMaxHealthFromHealthLevel();
            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            currentHealth = maxHealth;
            staminaBar.SetMaxStamina(maxStamina);
            healthBar.SetMaxHealth(maxHealth);
        }

        private float SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void StaminaWaste(int action)
        {
            currentStamina -= action;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void RegenerateStamina()
        {
            
            if (!_controller.isInteracting)
            {
                staminaRegenTimer += Time.deltaTime;
                if (currentStamina < maxStamina && staminaRegenTimer > 1f)
                {
                    currentStamina += staminaRegenerationAmount * Time.deltaTime;
                    staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
                }
            }
            else
            {
                staminaRegenTimer = 0;
            }
        }
        public void TakeDamage(int damage)
        {
            if (!isDead)
            {
                currentHealth -= damage;

                healthBar.SetCurrentHealth(currentHealth);

                animController.PlayTargetAnimation("Damage_01", true);

                if (currentHealth <= 0)
                {
                    Death();
                }
            }
        }
        public void Death()
        {
                isDead = true;
                currentHealth = 0;
                animController.PlayTargetAnimation("Death_01", true);
                _gameManager.EndGame();
                
        }
    }
}
