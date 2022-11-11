using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhisicalEntity
{
    [SerializeField] Souls soulsPrefab;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] int soulsCost;
    protected LineOfSight lineOfSight;
    private protected GameObject player;
    PatrollingEntity patrol;
    private Vector2 dirToPlayer;
    protected Animator anim;
    public bool isFacingRight = true, isChasing, canBePoweredUp, isStunned = false;


    protected override void Start()
    {
        base.Start();
        lineOfSight = GetComponentInChildren<LineOfSight>();
        anim = GetComponent<Animator>();
        player = PlayerGameMechanics.instance.gameObject;
        if (TryGetComponent<PatrollingEntity>(out var comp))
        {
            patrol = comp;
        }
    }

    protected virtual void Update()
    {
        isFacingRight = transform.right == new Vector3(1, 0, 0);
        isChasing = patrol.isChasing;
        dirToPlayer = (player.transform.position - transform.position).normalized;
        anim.SetFloat("speed", rb.velocity.magnitude);
        if (!isDead)
        {
            LookAtDirectionOfMovement();
        }
    }

    protected void LookAtDirectionOfMovement()
    {
        if (isFacingRight)
        {
            if ((isChasing) && (player.transform.position.x < transform.position.x))
            {
                Flip();
            }
            if ((!isChasing) && (rb.velocity.x < 0))
            {
                Flip();
            }
        }
        else
        {
            if ((isChasing) && (player.transform.position.x > transform.position.x))
            {
                Flip();
            }
            if ((!isChasing) && (rb.velocity.x > 0))
            {
                Flip();
            }
        }
    }

    public void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));

    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        LookAtPlayer();
    }


    protected virtual void AttackPlayer()
    {
    }

    public override void Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemyCollider.isTrigger = true;
        isDead = true;
        anim.SetTrigger("Die");
    }

    protected void DestroySelf()
    {
        Souls souls = Instantiate(soulsPrefab, transform.position, Quaternion.identity);
        souls.value = soulsCost;
        PlayerWeapon weapon = GetComponentInChildren<PlayerWeapon>();
        if (weapon != null)
        {
            weapon.transform.parent = null;
        }
        Destroy(gameObject);
    }

    protected void LookAtPlayer(bool locatePlayer = true)
    {
        if (locatePlayer)
        {
            lineOfSight.LocatePlayer();
        }
        if ((player.transform.position.x > transform.position.x) && (!isFacingRight))
        {
            Flip();
        }
        else if ((player.transform.position.x < transform.position.x) && (isFacingRight))
        {
            Flip();
        }
    }

    public void PowerUp()
    {
        SetMaxHp(maxHp * 2);
        foreach (HitTrigger stats in GetComponentsInChildren<HitTrigger>())
        {
            stats.dmg *= 2;
            stats.knockbackForce *= 2;
        }
        GetComponent<SpriteRenderer>().color = Color.red;
        canBePoweredUp = false;
        LookAtPlayer();
    }

    public void GetStunned(float stunTime)
    {
        StartCoroutine(ReseveStun(stunTime));
    }

    public IEnumerator ReseveStun(float stunTime)
    {
        if (!isStunned)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isStunned = true;
            yield return new WaitForSeconds(stunTime);
            isStunned = false;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void Respawn(bool restoreHP = false)
    {
        gameObject.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;      
        enemyCollider.isTrigger = false;
        if(restoreHP)
        {
            SetMaxHp(maxHp);
        }
    }


}


