using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBossHealthBar : MonoBehaviour
{
    public Text bossName;
    Slider slider;

    private void Awake() 
    {
        slider = GetComponentInChildren<Slider>();
        bossName = GetComponentInChildren<Text>();
    }
    private void Start()
    {
        SetUIHealthBarToInactive();
    }
    public void SetBossName(string name) 
    {
        bossName.text = name;
    }
    public void SetUIHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
        bossName.gameObject.SetActive(true);
    }
    public void SetUIHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
        bossName.gameObject.SetActive(false);
    }
    public void SetBossMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        SetBossCurrentHealth(maxHealth);
    }
    public void SetBossCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
