using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireUIMenu : MonoBehaviour
{
    [SerializeField] GameObject statMenu;

    void Start()
    {
        
    }

    public void OpenStatMenu()
    {
        statMenu.SetActive(true);
    }

    public void CloseStatMenu()
    {
        statMenu.SetActive(false);
    }

    public void CloseMenu()
    {
        CloseStatMenu();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
