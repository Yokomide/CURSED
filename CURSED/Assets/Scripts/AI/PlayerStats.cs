using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainHero
{
    public class PlayerStats : CharacterStats
    {
        public HealthBar healthBar;
        public AnimatorManager animController;
        void Start()
        {
            animController = GetComponent<AnimatorManager>();
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

            animController.PlayTargetAnimation("Damage_01", true);


            if (currentHealth <= 0)
            {
                Death();
            }
        }
        public void Death()
        {
                currentHealth = 0;
                animController.PlayTargetAnimation("Death_01", true);
        }
    }
}
