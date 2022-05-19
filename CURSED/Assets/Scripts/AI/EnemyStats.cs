using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyStats : CharacterStats
{

    EnemyBossManager enemyBossManager;
    public bool isDead;
    public bool isBoss;
    WorldEventManager worldEventManager;
    public int pointsToDrop;

    public ParticleSystem damageFX;
    public UIEnemyHealthBar enemyHealthBar;
    public StatsManager statsManager;

    [HideInInspector] public Animator anim;

    private void Awake()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        enemyBossManager = GetComponent<EnemyBossManager>();
        worldEventManager  = FindObjectOfType<WorldEventManager>();
    }
    void Start()
    {
        statsManager = GameObject.FindGameObjectWithTag("SM").GetComponent<StatsManager>();
        anim = GetComponent<Animator>();
        if (!isBoss)
        {
            enemyHealthBar.SetMaxHealth(maxHealth);
        }
        else if (isBoss && enemyBossManager != null)
        {
            enemyBossManager.UpdateBossHealthBar(currentHealth);
        }
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {

        Instantiate(damageFX, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        damageFX.Play();

        if (!isDead)
        {
            currentHealth = currentHealth - damage;
            if (!isBoss)
            {
                enemyHealthBar.SetHealth(currentHealth);
            }
            else if (isBoss && enemyBossManager != null)
            {
                enemyBossManager.UpdateBossHealthBar(currentHealth);
            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Damage_01"))
            {
                anim.Play("Damage_02");
            }
            else
            {
                anim.Play("Damage_01");
            }


            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }
    public void Death()
    {
        Destroy(gameObject.GetComponent<EnemyManager>());
        isDead = true;
        currentHealth = 0;
        if (!isBoss)
        {
            enemyHealthBar.SetHealth(currentHealth);

        }
        else if (isBoss && enemyBossManager != null)
        {
            enemyBossManager.UpdateBossHealthBar(currentHealth);
            worldEventManager.BossHasBeenDefeated();
        }
        anim.Play("Death_01");
        statsManager.GetPoints(pointsToDrop);
    }
}

