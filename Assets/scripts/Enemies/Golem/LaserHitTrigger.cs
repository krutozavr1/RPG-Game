using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHitTrigger : HitTrigger
{
    bool canDealDmg = true;
    [SerializeField] float cdForDmg;

    private void OnEnable()
    {
        canDealDmg = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhisicalEntity>(out var entity))
        {
            print("istays");
            if (canDealDmg)
            {
                print("can deal dmg;");
                entity.TakeDamage(dmg);
                StartCoroutine(CdForDmg());
            }

        }
    }

    
    IEnumerator CdForDmg()
    {
        canDealDmg = false;
        yield return new WaitForSeconds(cdForDmg);
        canDealDmg = true;
    }
}
