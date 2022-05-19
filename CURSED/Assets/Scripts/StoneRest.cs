using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainHero;

public class StoneRest : MonoBehaviour
{
    public TeleportStone teleportStone;

    public PlayerStats playerStats;

    public GameObject[] Cams;
    public GameObject Enemies;
    public GameObject interactButton;
    public GameObject UIButtons;
    public GameObject restMenu;
    public GameObject mainCamera;
    public GameObject restPoint;

    [SerializeField]
    private GameObject mainCharacter;

    private GameManager gm;
    public bool isStoneRest;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacter.GetComponent<ThirdPersonController>().stoneRest = gameObject.GetComponent<StoneRest>();
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

       Cams[0].SetActive(false);
       Cams[1].SetActive(false);

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
        gm.lastCheckPointPos = restPoint.transform.position;
        RespawnEnemies();
        ResetPlayerStats();

    }
    public void RespawnEnemies()
    {
        Destroy(GameObject.Find("Enemy(Clone)"));
        Destroy(GameObject.Find("Enemy"));
        Instantiate(Enemies);
    }
    public void ResetPlayerStats()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        playerStats.currentStamina = playerStats.maxStamina;
        playerStats.healthBar.SetCurrentHealth(playerStats.currentHealth);
        playerStats.staminaBar.SetCurrentStamina(playerStats.currentStamina);
    }
    public void EndRest()
    {
        mainCharacter.GetComponent<AnimatorManager>().PlayTargetAnimation("Empty", true);
    }
}
