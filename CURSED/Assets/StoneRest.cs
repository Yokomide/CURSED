using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRest : MonoBehaviour
{
    public TeleportStone teleportStone;
    public GameObject interactButton;
    public GameObject UIButtons;
    public GameObject restMenu;
    public GameObject mainCamera;
    public GameObject restPoint;

    [SerializeField]
    private GameObject mainCharacter;
    public bool isStoneRest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacter.GetComponent<MainHero.ThirdPersonController>().stoneRest = gameObject.GetComponent<StoneRest>();
            teleportStone.stoneRest = gameObject.GetComponent<StoneRest>();
            interactButton.SetActive(true);
            isStoneRest = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            isStoneRest = false;
        }
    }

    public void OnExitButtonPressed()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        restMenu.SetActive(false);
        UIButtons.SetActive(true);
        mainCamera.SetActive(true);
        EndRest();
    }

    public void StartRest()
    {
        mainCharacter.transform.position = restPoint.transform.position;
        mainCharacter.transform.rotation = restPoint.transform.rotation;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        mainCharacter.GetComponent<AnimatorManager>().PlayTargetAnimation("Rest", true);
    }
    public void EndRest()
    {
        mainCharacter.GetComponent<AnimatorManager>().PlayTargetAnimation("Empty", true);
    }
}
