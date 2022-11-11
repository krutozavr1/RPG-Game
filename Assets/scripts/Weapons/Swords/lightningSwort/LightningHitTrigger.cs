using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHitTrigger : HitTrigger
{
    Lightning lightning;

    private void Start()
    {
        lightning = GetComponent<Lightning>();
    }
    private void Update()
    {
        dmg = (int)lightning.dmg;
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
            DealDmg(entity.gameObject, dmg);
        }
    }

    public void DealDmg(GameObject target, int dmg)
    {
        target.GetComponent<PhisicalEntity>().TakeDamage(dmg);
    }
}
