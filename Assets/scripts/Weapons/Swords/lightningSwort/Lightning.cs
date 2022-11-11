using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SavableObject
{
    [SerializeField]GameObject sword;
    [SerializeField] LayerMask enemyLayer;
    GameObject prevTarget = null, nearestTarget = null;
    float explosiveRadius, baseRadius = 7, baseDmg = 20;
    public float dmg;
    Vector2  baseScale = new Vector2(6, 8.5f);

    private void SetNormalSizeAndStats()
    {
        transform.localScale = baseScale;
        prevTarget = null;
        explosiveRadius = baseRadius;
        dmg = baseDmg;
        transform.up = Vector3.left;
    }
    public void Strike(Vector2 pos)
    {
        SetNormalSizeAndStats();
        transform.parent = null;
        transform.position = pos;
        gameObject.SetActive(true);
    }

    private void Disappear()
    {
        transform.SetParent(sword.transform);
        gameObject.SetActive(false);
    }

    private void SearchForNearbyTargets()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, enemyLayer);
        nearestTarget = null;
        float minDist = 1000;
        foreach (Collider2D hit in hits)
        {

                float distToTarget = Vector2.Distance(transform.position, hit.transform.position);
                if ((distToTarget < minDist) && (prevTarget!= hit.gameObject) && (!hit.GetComponent<PhisicalEntity>().isDead))
                {
                    nearestTarget = hit.gameObject;
                    minDist = distToTarget;
                }
            
        }
        if(nearestTarget != null)
        {
            GoToNearbyTarget(nearestTarget);
        }
        else
        {
            Disappear();
        }
    }

    private void GoToNearbyTarget(GameObject target)
    {
        gameObject.SetActive(false);// to reset anim
        gameObject.SetActive(true);
        ResizeObject(target);
        prevTarget = nearestTarget;
        explosiveRadius *= .9f;
        dmg *= .9f;
    }

    private void ResizeObject(GameObject target)
    {
        Vector3 scale = transform.localScale;
        scale.Set(Vector2.Distance(target.transform.position, transform.position), Vector2.Distance(target.transform.position, transform.position)* .4f, 1);
        transform.localScale = scale;
        transform.right = -(target.transform.position - transform.position).normalized;
        transform.position = target.transform.position;
    }

}
