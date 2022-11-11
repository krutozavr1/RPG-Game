using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
