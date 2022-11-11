using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitTrigger : HitTrigger
{
    TrowingAxe axe;
    void Start()
    {
        axe = FindObjectOfType<TrowingAxe>();
    }

    void Update()
    {
        dmg = axe.dmg;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhisicalEntity>(out var entity))
        {
            if (knockbackForce != 0)//cant knockback
            {
                entity.TakeKnockback(knockbackForce, (entity.transform.position - transform.position).normalized);
            }
            if (stunTime != 0)
            {
                Enemy enemy;
                if (entity.TryGetComponent(out enemy))
                {
                    enemy.GetStunned(stunTime);
                }
            }
            entity.TakeDamage(dmg);
            if ((!axe.isCharged) && (entity.GetComponent<PhisicalEntity>().curHp > 0))
            {
                axe.Stop(collision.transform);
            }
            
        }
    }


}
