using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   bool gameHasEnded = false;
   public float restartDelay;

    private void Start()
    {
        LevelManager.Instance.GetComponentInChildren<Settings>().PostProcessState();
    }
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        
        LevelManager.Instance.LoadScene("Village");
    }
}
