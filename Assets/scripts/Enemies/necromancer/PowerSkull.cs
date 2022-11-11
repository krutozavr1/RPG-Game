using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSkull : PhisicalEntity
{
    [SerializeField]LayerMask enemyLayer;
    [SerializeField] float radius;
    bool targetFound = false;
    GameObject nearestEnemy;
    float speed = 7, distToPlayer;

    void Awake()
    {
        StartCoroutine(WaitForEnemy());
    }

    void Update()
    {
        if((targetFound) && (nearestEnemy != null))
        {
            FlyToEnemy(nearestEnemy);
        }
        distToPlayer = Vector2.Distance(PlayerMovement.instance.transform.position, transform.position);
    }

    private void FindNearestEnemy()
    {
        if(distToPlayer < radius)
        {
            float minDist = 999;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
            foreach (Collider2D hit in hits)
            {
                float distToCurEnemy = Vector2.Distance(transform.position, hit.transform.position);
                if (distToCurEnemy < minDist)
                {
                    if(hit.GetComponent<Enemy>())
                    {
                        if(hit.GetComponent<Enemy>().canBePoweredUp)
                        {
                            minDist = distToCurEnemy;
                            nearestEnemy = hit.gameObject;
                            targetFound = true;
                        }

                    }
                }
            }

        }
    }

    private void FlyToEnemy(GameObject enemy)
    {
        rb.velocity = (nearestEnemy.transform.position - transform.position).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<Enemy>().PowerUp();
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
    
    IEnumerator WaitForEnemy()
    {
        while(!targetFound)
        {
            FindNearestEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }
}
