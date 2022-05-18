using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{
    [SerializeField]
    WorldEventManager worldEventManager;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject camera;
    [SerializeField]
    GameObject UI;
    [SerializeField]
    GameObject CutScene;
    [SerializeField]
    GameObject AudioManager;

    public AudioClip BossFight;
    private void OnTriggerEnter(Collider other)
    {
        if (!worldEventManager.bossFightIsActive)
        {
            if (!worldEventManager.bossHasBeenDefeated && other.tag == "Player")
            {
                worldEventManager.ActivateBossFight();

                CutScene.SetActive(true);

                AudioManager.GetComponent<AudioSource>().clip = BossFight;
                AudioManager.GetComponent<AudioSource>().Play();
            }
        }

          //  player.SetActive(false);
          //  camera.SetActive(false);
        }
}
