using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static bool isPostProcessingOn = true;

    public void PostProcessState()
    {
        if (!isPostProcessingOn)
        {
            GameObject.Find("PostProcess").SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void PostProcessBool()
    {
        if (isPostProcessingOn)
        {
            isPostProcessingOn = false;
        }
        else
        {
            isPostProcessingOn = true;
        }
        Debug.Log(isPostProcessingOn);
    }
}