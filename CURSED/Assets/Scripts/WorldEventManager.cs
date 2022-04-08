using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventManager : MonoBehaviour
{
    public UIBossHealthBar bossHealthBar;
    public EnemyBossManager boss;

    public bool bossFightIsActive;
    public bool bossHasBeenAwakened;
    public bool bossHasBeenDefeated;

    private void Awake() 
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
    }
    public void ActivateBossFight()
    {
        bossFightIsActive = true;
        bossHasBeenAwakened = true;
        bossHealthBar.SetUIHealthBarToActive();
    }
    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        bossHealthBar.SetUIHealthBarToInactive();
    }
}
