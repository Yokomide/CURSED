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
        public ManaBar manaBar;
        public AnimatorManager animController;
        public ParticleSystem bloodFX;
        public ShakeCameras camController;
        public float staminaRegenerationAmount = 30;
        public float staminaRegenTimer = 0;

        public int bloodPoints;

        [SerializeField]
        private GameManager gm;

        private ThirdPersonController _controller;
        public bool isDead;
        public StatsManager statsManager;
        public HitSound hitSound;
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
            statsManager = GameObject.FindGameObjectWithTag("SM").GetComponent<StatsManager>();
            _controller = GetComponent<ThirdPersonController>();
            animController = GetComponent<AnimatorManager>();
            hitSound = GetComponent<HitSound>();
            maxHealth = SetMaxHealthFromHealthLevel();
            maxStamina = SetMaxStaminaFromStaminaLevel();
            maxMana = SetMaxManaFromManaLevel();
            currentStamina = maxStamina;
            currentHealth = maxHealth;
            currentMana = maxHealth;
            staminaBar.SetMaxStamina(maxStamina);
            healthBar.SetMaxHealth(maxHealth);
            manaBar.SetMaxMana(maxMana);
            GameObject playerStats = GameObject.Find("Character");
            if (playerStats != null)
            {
                statsManager.GetFlask(0);
                statsManager.GetPoints(0);
                playerStats.GetComponent<PlayerStats>().LoadPlayer();
                
            }
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
        private int SetMaxManaFromManaLevel()
        {
            maxMana = manaLevel * 10;
            return maxMana;
        }
        public void StaminaWaste(int action)
        {
            currentStamina -= action;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void ManaWaste(int action)
        {
            currentMana -= action;
            manaBar.SetCurrentMana(currentMana);
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
                hitSound.PlayHit();
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
            SavePlayer();
                gm.EndGame();            
        }
        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            maxHealth = data.maxHp;
            maxMana = data.maxMana;
            maxStamina = data.maxStamina;

            bloodPoints = data.bloodPoints;
        }
    }
}
