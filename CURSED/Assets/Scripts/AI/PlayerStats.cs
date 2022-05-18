using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainHero
{
    public class PlayerStats : CharacterStats
    {
        //public Vibrator vibrator;
        public HealthBar healthBar;
        public StaminaBar staminaBar;
        public AnimatorManager animController;
        public ParticleSystem bloodFX;
        public ShakeCameras camController;
        public float staminaRegenerationAmount = 30;
        public float staminaRegenTimer = 0;

        [SerializeField]
        private GameManager gm;

        private ThirdPersonController _controller;
        public bool isDead;
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
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

                Vibrator.Vibrate();
                float shakeIntensity = 5f;
                camController.ShakeCamera(shakeIntensity, .1f);

                Instantiate(bloodFX, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
               bloodFX.Play();

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
                gm.EndGame();            
        }
    }
}
