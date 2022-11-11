using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopFlag : MonoBehaviour
{
    [SerializeField]
    GameObject shop;
    [SerializeField]
    GameObject[] weapons, secWeapons, usables, bonuses;
    bool canOpenShop = false, alreadyOrganizedShop = false;


    void Start()
    {
    }

    void Update()
    {
        if ((Keyboard.current.eKey.isPressed) && (canOpenShop))
        {
            OpenShop();
            if(!alreadyOrganizedShop)
            {
                alreadyOrganizedShop = true;
                FindObjectOfType<Shop>().OrganizeShop(weapons, secWeapons, usables, bonuses);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Tutorial.instance.Activate();
            canOpenShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Tutorial.instance.Deactivate();
            canOpenShop = false;
        }
    }


    void OpenShop()
    {
        shop.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
