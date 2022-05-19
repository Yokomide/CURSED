using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class Vendor : MonoBehaviour
{

    public GameObject interactButton;
    public GameObject UIButtons;
    public GameObject tradeMenu;
    public GameObject errorMenu;
    public StatsManager statsManager;

    [SerializeField]
    private GameObject mainCharacter;
    public bool isNearVendor;

    private void Start()
    {
        statsManager = GameObject.FindGameObjectWithTag("SM").GetComponent<StatsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacter.GetComponent<ThirdPersonController>().vendor = gameObject.GetComponent<Vendor>();
            interactButton.SetActive(true);
            isNearVendor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            isNearVendor = false;
        }
    }
    public void OnExitButtonPressed()
    {
        CloseError();
        tradeMenu.SetActive(false);
        UIButtons.SetActive(true);
    }

    public void BuyAxe()
    {
        if(statsManager.bloodPoints>= 150)
        {
            statsManager.GetPoints(-150);
            mainCharacter.GetComponent<PlayerInventory>().addAxe();
            mainCharacter.GetComponent<PlayerInventory>().CheckWeaponInventory();
        }
        else
        {
            CloseError();
        }
    }

    public void BuySpear()
    {
        if (statsManager.bloodPoints >= 250)
        {
            statsManager.GetPoints(-250);
            mainCharacter.GetComponent<PlayerInventory>().addSpear();
            mainCharacter.GetComponent<PlayerInventory>().CheckWeaponInventory();
        }
        else
        {
            CloseError();
        }
    }

    public void BuyFlask()
    {

    }

    public void BuySpell()
    {

    }


    public void CloseError()
    {
        errorMenu.SetActive(false);
    }
}
