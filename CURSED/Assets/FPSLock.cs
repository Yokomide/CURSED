using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    public int targetFPS;
    void Start()
    {
        Application.targetFrameRate = targetFPS;
    }

}