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
            GameManager.instance.lastCheckPointPos = new Vector3(1.56f, 0.38f, -23.65f);
        }
    }
}
