using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().Death();
        }
    }
}
