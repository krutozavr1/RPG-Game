using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souls : MonoBehaviour
{
    public int value = 0;
    float speed = 8f;
    Player player;
    Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FlyToPlayer();
    }

    private void FlyToPlayer()
    {
        rb.velocity = speed * (player.transform.position - transform.position).normalized;
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.right = player.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CollectSouls();
            Destroy(gameObject);
        }
    }

    private void CollectSouls()
    {
        MoneyCount.instance.ChangeMoneyScore(value);
        value = 0;
    }
}
