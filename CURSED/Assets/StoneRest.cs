using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRest : MonoBehaviour
{
   [SerializeField]
    private GameObject interactButton;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject mainCharacter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactButton.SetActive(false);
        }
    }

    public void OnInteractButtonPressed()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        mainCamera.SetActive(false);
        StartRest();
    }

    public void StartRest()
    {
        Debug.Log("Да");
        mainCharacter.GetComponent<AnimatorManager>().PlayTargetAnimation("Rest", true);
    }
}
