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

    private GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
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
            gm.lastCheckPointPos = restPoint[0].transform.GetChild(3).gameObject.transform.position;
        }
        else
        {
            restPoint[0].transform.GetChild(0).gameObject.SetActive(false);
            gm.lastCheckPointPos = restPoint[1].transform.GetChild(3).gameObject.transform.position;
        }
       // restPoint[point].transform.GetChild(0).gameObject.SetActive(true);

        stoneRest.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        stoneRest.restMenu.SetActive(false);
        stoneRest.UIButtons.SetActive(true);
        stoneRest.mainCamera.SetActive(true);
        stoneRest.EndRest();

    }
}
