using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

}