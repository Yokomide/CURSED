using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class UseFlask : MonoBehaviour
{
    public StatsManager statsManager;
    public PlayerStats playerStats;
    public HealthBar healthBar;

    private void Start()
    {
        statsManager = GameObject.FindGameObjectWithTag("SM").GetComponent<StatsManager>();
        playerStats = GetComponent<PlayerStats>();

    }

    public void FlaskUse()
    {
        if (statsManager.flaskPoints >=1)
        {
            statsManager.GetFlask(-1);
            playerStats.currentHealth += 30;
            if (playerStats.currentHealth > playerStats.maxHealth)
            {
                playerStats.currentHealth = playerStats.maxHealth;
            }
            healthBar.SetCurrentHealth(playerStats.currentHealth);
        }

    }
}
