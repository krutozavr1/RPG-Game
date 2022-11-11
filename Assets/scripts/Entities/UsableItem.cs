using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UsableItem : MonoBehaviour
{

    bool canBeUsed = false;


    private void Update()
    {
        if ((Keyboard.current.uKey.IsPressed()) && (canBeUsed))
        {
            UseItem();
        }

    }

    public virtual void UseItem()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canBeUsed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canBeUsed = false;
        }
    }
}
