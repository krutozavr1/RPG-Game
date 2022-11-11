using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEntity : MonoBehaviour
{

    [SerializeField] float patrollingSpeed, maxSpeed, acceleration;
    [SerializeField]LayerMask playerLayer;

    LineOfSight lineOfSight;
    Transform player;
    public bool isChasing = false;
    bool isPatrolling = false, seesPlayer = false;
    Rigidbody2D rb;
    Vector2 dirToPlayer;


    void Start()
    {
        player = PlayerMovement.instance.gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        lineOfSight = GetComponentInChildren<LineOfSight>();
    }

    void Update()
    {
        dirToPlayer = (player.position - transform.position).normalized;
        seesPlayer = lineOfSight.seesPlayer;
        if (seesPlayer)
        {
            if(isPatrolling)
            {
                StopPatrolling();
            }
            else
            {

                ChasePlayer();
            }
        }
        else if (!isPatrolling)
        {
            StartPatrolling(); ;
        }
    }

    private void StartPatrolling()
    {
        isPatrolling = true;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (isPatrolling)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * patrollingSpeed;
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }

    private void StopPatrolling()
    {
        isPatrolling = false;

    }

    private void ChasePlayer()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            if (Mathf.Abs(rb.velocity.x + dirToPlayer.x * acceleration) < Mathf.Abs(rb.velocity.x))
            {
                rb.velocity += new Vector2(dirToPlayer.x * acceleration, 0);
            }

        }
        else
        {
            rb.velocity += new Vector2(dirToPlayer.x * acceleration, 0);
        }
        if (Mathf.Abs(rb.velocity.y) > maxSpeed)
        {
            if (Mathf.Abs(rb.velocity.y + dirToPlayer.y * acceleration) < Mathf.Abs(rb.velocity.y))
            {
                rb.velocity += new Vector2(0, dirToPlayer.y * acceleration);
            }
        }
        else
        {
            rb.velocity += new Vector2(0, dirToPlayer.y * acceleration);
        }
    }

    public void SlowItself()
    {
        patrollingSpeed *= .8f;
        maxSpeed *= .8f;
        acceleration *= .8f;
    }

    private void ReturnToNormalSpeed()
    {
        patrollingSpeed /= .8f;
        maxSpeed /= .8f;
        acceleration /= .8f;

    }
}
