using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{
    WorldEventManager worldEventManager;
    void Awake()
    {
        worldEventManager  = FindObjectOfType<WorldEventManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!worldEventManager.bossHasBeenDefeated && other.tag == "Player")
        {
            worldEventManager.ActivateBossFight();
        }
    }
}