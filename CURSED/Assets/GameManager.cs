using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MainHero;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    bool gameHasEnded = false;
    public float restartDelay;
    public Vector3 lastCheckPointPos;

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
        LevelManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        gameHasEnded = false;

    }
}
