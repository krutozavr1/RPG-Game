using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 2.5f;
    bool wasDeflected = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    void Update()
    {
        if(!wasDeflected)
        {
            rb.velocity = (GameManager.instance.player.transform.position - transform.position).normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HitTrigger>() != null)
        {
            Deflect((transform.position - collision.transform.position).normalized);
        }
        if(collision.GetComponent<PhisicalEntity>() != null)
        {
            Destroy(gameObject);
        }
    }

    private void Deflect(Vector2 dir)
    {
        speed *= 2;
        wasDeflected = true;
        rb.velocity = dir * speed;
    }
}
