using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTracker : MonoBehaviour
{
    PlayerGameMechanics mechs;
    void Start()
    {
        mechs = GetComponent<PlayerGameMechanics>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "key")
        {

            Destroy(collision.gameObject);
        }
    }
}
