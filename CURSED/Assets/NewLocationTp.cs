using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLocationTp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.LoadScene("Swamp");
        }
    }
}
