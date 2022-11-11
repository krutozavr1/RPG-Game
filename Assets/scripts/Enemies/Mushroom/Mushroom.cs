using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    [SerializeField] GameObject projectilePrefab, projectileSpawnPoint;
    float castCd = 5, runningTime = 0, timePassed = 0, runningSpeed = 2;
    bool isRunningAway = false, seesPlayer = false;

    private void Awake()
    {
        lineOfSight = GetComponentInChildren<LineOfSight>();
    }

    protected override void Update()
    {
        isFacingRight = transform.right == new Vector3(1, 0, 0);
        seesPlayer = lineOfSight.seesPlayer;
        if (isRunningAway)
        {
            if (runningTime < 3)
            {
                RunAway();
            }
            else
            {
                StopRunning();
            }
        }
        else if(seesPlayer)
        {
            LookAtPlayer(false);
            if(timePassed > castCd)
            {
                AttackPlayer(); 
            }
            
        }
        timePassed += Time.deltaTime;
        ControlSpeed();
    }

    private void ControlSpeed()
    {
        float distToPlayer = (transform.position - player.transform.position).magnitude;
        if(distToPlayer < 3)
        {
            runningSpeed = 6;
        }
        else if(distToPlayer < 5)
        {
            runningSpeed = 4.5f;
        }
        else
        {
            runningSpeed = 3;
        }
    }

    private void LookAtDirectionOfRunning()
    { 
        if((rb.velocity.x < 0) && (isFacingRight))
        {
            Flip();
        }
        else if((rb.velocity.x > 0) && (!isFacingRight))
        {
            Flip();
        }
    }

    public override void TakeDamage(int dmg)
    {
        if(!isDead)
        {
            isRunningAway = true;
            anim.SetBool("isRunning", true);
            base.TakeDamage(dmg);
        }
        else
        {
            
        }      
    }

    public override void Die()
    {
        DestroySelf();
    }

    private void RunAway()
    {
        rb.velocity = (transform.position - player.transform.position).normalized * runningSpeed;
        LookAtDirectionOfRunning();
        runningTime += Time.deltaTime;
    }

    private void StopRunning()
    {
        isRunningAway = false;
        rb.velocity = Vector2.zero;
        runningTime = 0;
        anim.SetBool("isRunning", false);
    }

    protected override void AttackPlayer()
    {
        anim.SetTrigger("cast");
        timePassed = 0;
    }

    private void SpawnProjectile()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, Quaternion.identity);

    }

    

}
