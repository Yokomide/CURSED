using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;

    public int bloodPoints;

    public TextMeshProUGUI blood;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void GetPoints(int a)
    {
        blood = GameObject.Find("Blood").GetComponent<TextMeshProUGUI>();
        bloodPoints += a;
        blood.text = bloodPoints.ToString();
    }
}
