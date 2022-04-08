using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    public string bossName;

    UIBossHealthBar bossHealthBar;
    EnemyStats enemyStats;

    private void Awake() 
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Start() 
    {
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(enemyStats.maxHealth);
    }
    public void UpdateBossHealthBar(int currentHealth)
    {
        bossHealthBar.SetBossCurrentHealth(currentHealth);
    }
}
