using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{

    public  int dmg, knockbackForce;
    public float stunTime;
    [SerializeField] bool destroyObjectOnImpact = false;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PhisicalEntity>(out var entity))
        {
            if (knockbackForce != 0)//cant knockback
            {
                entity.TakeKnockback(knockbackForce, (entity.transform.position - transform.position).normalized);
            }
            if(stunTime != 0)
            {
                Enemy enemy;
                if(entity.TryGetComponent(out enemy))
                {
                    enemy.GetStunned(stunTime);
                }
            }
            entity.TakeDamage(dmg);
            if(destroyObjectOnImpact)
            {
                if(transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
