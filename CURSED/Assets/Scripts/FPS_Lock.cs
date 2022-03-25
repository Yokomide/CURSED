using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Lock : MonoBehaviour
{
    void Awake()
    {
      QualitySettings.vSyncCount = 0;
      Application.targetFrameRate = 60;
    }
}
