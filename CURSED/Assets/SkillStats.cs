using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class SkillStats : MonoBehaviour
{
    public PlayerStats stats;

    Collider damageCollider;
    public GameObject damageFX;
    public int currentSkillDamage = 40;

    void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }
    private void Start()
    {
        stats = GameObject.Find("Character").GetComponent<PlayerStats>();
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentSkillDamage);

            }
        }
    }

    public void StaminaWaste(int cost)
    {
        stats.StaminaWaste(cost);
    }
    public void ManaWaste(int cost)
    {
        stats.ManaWaste(cost);
    }
}
