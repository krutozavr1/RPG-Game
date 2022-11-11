using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    public GameObject player, knifePrefab, grenadePrefab, deathScreen, pauseScreen;
    [SerializeField]
    public Camera cam;
    public bool enemiesAreSlown = false, gameIsPaused = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape) && (!gameIsPaused))
        {
            PauseTheGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (gameIsPaused))
        {
            ResumeTheGame();
        }*/
        if (Keyboard.current.qKey.isPressed)
        {
            SceneManager.LoadScene(1);
        }

    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    void PauseTheGame()
    {
        gameIsPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeTheGame()
    {
        pauseScreen.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
    }
}
