using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    public int currentWeaponDamage = 25;
    void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        Debug.Log("Включился");
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        Debug.Log("ВЫключився");
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player ")
        {
            Debug.Log("ПЛАВУВЕР");
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if (other.tag == "Enemy")
        {
            Debug.Log("ЭНЕМЯ");
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
