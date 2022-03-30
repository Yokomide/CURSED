using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class EnemyStats : CharacterStats
    {
        public HealthBar healthBar;
        [HideInInspector]public Animator anim;
        void Start()
        {
            anim = GetComponent<Animator>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
           // healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

          //  healthBar.SetCurrentHealth(currentHealth);

           anim.Play("Damage_01");


            if (currentHealth <= 0)
            {
                currentHealth = 0;
                anim.Play("Death_01");
            }
        }
    }

