using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWall : MonoBehaviour
{
    public GameObject Fog;
    private void Awake() 
    {
       Fog.SetActive(false);
    }
    public void ActivateFogWall()
    {
        Fog.SetActive(true);
    }
    public void DeactivateFogWall()
    {
        Fog.SetActive(false);
    }
}
