using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

[System.Serializable]
public class PlayerData
{
    public int HeroHp;
    public int maxHp;
    public float maxStamina;
    public int maxMana;
    public int HeroMana;
    public int bloodPoints;



    public PlayerData(PlayerStats player)
    {
        //HeroHp = player.currentHealth;
        //HeroMana = player.currentMana;
        maxHp = player.maxHealth;
        maxStamina = player.maxStamina;
        maxMana = player.maxMana;
        //bloodPoints= points.bloodPoints;
    }

}
