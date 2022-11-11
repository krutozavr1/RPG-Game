using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AttackPlayer();
        }
    }

    protected override void AttackPlayer()
    {
        anim.SetTrigger("Attack");
    }

    private void ResetAttackTrigger()
    {
        anim.ResetTrigger("Attack");
    }
}
