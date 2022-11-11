using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueShopFlag : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


        }

    }

    void TeleportPlayer()
    {
        print("tp");
    }
}
