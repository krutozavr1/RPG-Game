using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemProjectile : DeflectableProjectile
{

    [SerializeField] bool aimsAtPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 6);
    }

    protected override void Update()
    {
        if(aimsAtPlayer && !wasDeflected)
        {
            rb.velocity = (PlayerMovement.instance.transform.position - transform.position).normalized * speed;
        }
        transform.right = rb.velocity;
    }
}
