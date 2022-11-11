using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHitTrigger : HitTrigger
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponentInParent<RocketGlove>().BecomeIdle();
        }
        else if (collision.TryGetComponent<PhisicalEntity>(out var entity))
        {
            if (knockbackForce != 0)//cant knockback
            {
                entity.TakeKnockback(knockbackForce, (entity.transform.position - transform.position).normalized);
            }
            entity.TakeDamage(dmg);
            GetComponentInParent<RocketGlove>().FindNewTarget();
        }
    }


}
