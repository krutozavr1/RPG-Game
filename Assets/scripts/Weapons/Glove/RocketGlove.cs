using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketGlove : Weapon
{

    [SerializeField] float speed;
    [SerializeField] LayerMask enemyLayer;
    Rigidbody2D rb;
    GameObject prevTarget, curTarger;
    bool isLaunched = false, isAttacking = false;


    protected override void Update()
    {

        if (isLaunched)
        {
            FlyToTarget();
            LookAtTarget();
        }
    }

    public void OnAttack(InputValue value)
    {
        if(!isLaunched)
        {
            Launch();
        }
    }

    private void Launch()
    {
        transform.parent = null;
        isLaunched = true;
        anim.SetBool("isLaunched", true);
        CreateNewRigidBody();
        FindNewTarget();
    }

    private void CreateNewRigidBody()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void FindNewTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 15, enemyLayer);
        float minDist = 1000;
        List<GameObject> acitveEnemies = new List<GameObject>();
        foreach(Collider2D enemy in enemies)
        {
            if(!enemy.GetComponent<Enemy>().isDead)
            {
                acitveEnemies.Add(enemy.gameObject);
            }
        }
        if (acitveEnemies.Count > 0)
        {
            foreach (GameObject enemy in acitveEnemies)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) < minDist)
                {
                    if ((enemy != prevTarget) || (acitveEnemies.Count == 1))
                    {
                        if(enemy.activeInHierarchy)
                        {
                            curTarger = enemy.transform.gameObject;
                            minDist = Vector2.Distance(transform.position, enemy.transform.position);
                        }
                    }
                }

            }
            prevTarget = curTarger;
            AttackTarget();
        }
        else
        {
            ReturnToPlayer();
        }
    }

    private void AttackTarget()
    {
        isAttacking = true;
    }

    private void FlyToTarget()
    {
        if (curTarger != null)
        {
            rb.velocity = speed * (curTarger.transform.position - transform.position).normalized;
        }
        else
        {
            FindNewTarget();
        }
    }

    private void LookAtTarget()
    {
        if (curTarger != null)
        {
            transform.right = curTarger.transform.position - transform.position;

        }
    }

    private void ReturnToPlayer()
    {
        curTarger = playerMove.gameObject;
    }

    public void BecomeIdle(bool forceIdle = false)
    {
        if((curTarger == playerMove.gameObject) || (forceIdle))
        {
            Destroy(rb);
            isAttacking = false;
            isLaunched = false;
            anim.SetBool("isLaunched", false);
            transform.parent = playerMove.transform;
            transform.localPosition = startPos;
            transform.rotation = Quaternion.Euler(new Vector3(0, playerMove.transform.rotation.y, startRot.z));
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        BecomeIdle(true);
    }

}
