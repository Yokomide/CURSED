using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStone : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject[] restPoint;
    public GameObject restPlaces;
    public GameObject moveButton;
    public StoneRest stoneRest;
    public GameObject Fade;
    public void OnChooseButtonPressed()
    {
        restPlaces.SetActive(true);
        moveButton.SetActive(false);
    }
    public void OnTeleportButtonPressed(int point)
    {
        Fade.GetComponent<Animator>().Play("TransitionFadeOut", - 1, 0f);
        mainCharacter.transform.position = restPoint[point].transform.GetChild(3).gameObject.transform.position;
        mainCharacter.transform.rotation = restPoint[point].transform.GetChild(3).gameObject.transform.rotation;
        if (point == 0 )
        {
            restPoint[1].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            restPoint[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        restPoint[point].transform.GetChild(0).gameObject.SetActive(true);

    }
}
