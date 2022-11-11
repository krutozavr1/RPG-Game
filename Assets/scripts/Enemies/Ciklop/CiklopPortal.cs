using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiklopPortal : MonoBehaviour
{
    void DestroySelf()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //collision.GetComponent<PlayerGameMechanics>().GetDamage(20);
            //collision.GetComponent<PlayerGameMechanics>().GetKnockback(3, (collision.transform.position - transform.position).normalized);
        }
    }
}
