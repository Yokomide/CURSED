using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    
    private void Start() {
        slider = GetComponent<Slider>();
    }
    public void SetMaxMana(float maxMana)
    {
        slider.maxValue = maxMana;
        slider.value = maxMana;
    }
    public void SetCurrentMana(float currentMana)
    {
        slider.value = currentMana;
    }
}
