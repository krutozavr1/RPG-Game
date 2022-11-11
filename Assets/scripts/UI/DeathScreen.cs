using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDeathScreen()
    {
        anim.SetBool("isActive", true);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void StartNewRun()
    {
        anim.SetBool("isActive", false);
        BonfireSystem.instance.RespawnAllEntities();
    }
}
