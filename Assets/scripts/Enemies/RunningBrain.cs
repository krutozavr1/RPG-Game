using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBrain : PhisicalEntity
{
    [SerializeField] GameObject pocketSoulsPrefab;
    [SerializeField]LayerMask playerLayer;
    [SerializeField] float radiusOfSight, speed;
    Player player;
    Vector2 dirToPlayer;
    Animator anim;
    bool isRunning = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        dirToPlayer = (player.transform.position - transform.position).normalized;
        CheckDistanceToPlayer();
        if(isRunning)
        {
            RunAway();
        }
    }

    private void CheckDistanceToPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer, radiusOfSight, playerLayer);
        if(hit)
        {
            StartRunning();
        }
    }

    private void StartRunning()
    {
        isRunning = true;
        anim.SetBool("isRunning", true);
    }

    private void RunAway()
    {
        rb.velocity = speed * (-dirToPlayer);
        LookAtDirectionOfMovement();
        if(Vector2.Distance(transform.position, player.transform.position) > 6)
        {
            StartTeleporting();
        }
    }


    private void StartTeleporting()
    {
        rb.velocity = Vector2.zero;
        isRunning = false;
        anim.SetBool("isRunning", false);
        anim.SetTrigger("teleport");
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

    public override void Die()
    {
        GameObject pocketSouls = Instantiate(pocketSoulsPrefab, transform.position, Quaternion.identity);
        pocketSouls.GetComponent<PocketSouls>().SetValue(Random.Range(100, 300));
        base.Die();
    }

    private void LookAtDirectionOfMovement()
    {
        if(rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
}
