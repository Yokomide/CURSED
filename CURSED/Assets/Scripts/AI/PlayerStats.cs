using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainHero
{
    public class PlayerStats : CharacterStats
    {
        public HealthBar healthBar;
        public ThirdPersonController controller;
        void Start()
        {
            controller = GetComponent<ThirdPersonController>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            controller.PlayTargetAnimation("Damage_01", true);


            if (currentHealth <= 0)
            {
                currentHealth = 0;
                controller.PlayTargetAnimation("Death_01", true);
            }
        }
    }
}
