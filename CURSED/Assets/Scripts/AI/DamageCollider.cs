using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    public GameObject damageFX;
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
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
                //damageFX.GetComponent<ParticleSystem>().Play();
            }
        }

        if (other.tag == "Enemy")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
                
            }
        }
    }
}
