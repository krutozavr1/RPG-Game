using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectableProjectile : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed = 2.5f;
    protected bool wasDeflected = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    protected virtual void Update()
    {
        if (!wasDeflected)
        {
            rb.velocity = (GameManager.instance.player.transform.position - transform.position).normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HitTrigger>() != null)
        {
            Deflect((transform.position - collision.transform.position).normalized);
        }
    }

    private void Deflect(Vector2 dir)
    {
        speed *= 2;
        wasDeflected = true;
        rb.velocity = dir * speed;
    }
}
