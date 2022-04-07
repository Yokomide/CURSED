using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainHero
{
    public class PlayerStats : CharacterStats
    {
        public HealthBar healthBar;
        public AnimatorManager animController;

        [SerializeField]
        private GameManager _gameManager;

        public bool isDead;
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
            if (!isDead)
            {
                currentHealth = currentHealth - damage;

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
