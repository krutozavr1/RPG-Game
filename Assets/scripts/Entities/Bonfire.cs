using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bonfire : MonoBehaviour
{
    public Transform spawnPoint;
    bool isActive = false, canInteract = false;
    Animator anim;
    BonfireUIMenu menu;

    void Start()
    {
        anim = GetComponent<Animator>();
        menu = FindObjectsOfType<BonfireUIMenu>(true)[0];
    }

    void Update()
    {
        if(canInteract)
        {

            Tutorial.instance.Activate();
            if(!isActive)
            {
                if(Keyboard.current.eKey.wasReleasedThisFrame)
                {
                    FireNormally();

                }
            }
            else if (isActive)
            {
                if (Keyboard.current.eKey.wasReleasedThisFrame)
                {
                    ActivateBonfire();

                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canInteract = false;
            Tutorial.instance.Deactivate();
        }
    }

    public void FireNormally()
    {
        isActive = true;
        anim.SetTrigger("BecomeActive");
    }

    void ActivateBonfire()
    {
        BonfireSystem.instance.SetActiveBonfire(this);
        anim.SetTrigger("BecomeBloody");
        menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }


}
