using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PhisicalEntity
{
    public float speed, speedBonus;
    public bool isFacingRight = true, canMove = true;
    public static PlayerMovement instance;
    Vector2 moveDir;
    Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            anim.SetFloat("speed", Mathf.Abs(moveDir.x) + Mathf.Abs(moveDir.y));

        }
    }


    public void OnMove(InputValue input)
    {
        moveDir = input.Get<Vector2>();
        CheckDirection();
        rb.velocity = moveDir * speed * speedBonus;
    }
   

    void CheckDirection()
    {
        if ((isFacingRight) && ( moveDir.x < 0))
        {
            Flip();
        }
        else if ((!isFacingRight) && (moveDir.x > 0))
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        isFacingRight = !isFacingRight;
    }


    public override void TakeKnockback(float force, Vector2 dir)
    {
        if(!isInvinsible)
        {

            StartCoroutine(GetKnockBack(force, dir));
        }
    }

    private IEnumerator GetKnockBack(float force, Vector2 dir)
    {
        canMove = false;
        rb.velocity = force * dir;
        anim.SetBool("isStunned", !canMove);

        yield return new WaitForSeconds(.5f);

        canMove = true;
        anim.SetBool("isStunned", !canMove);

    }

    public override void TakeDamage(int dmg)
    {
        PlayerGameMechanics.instance.TakeDamage(dmg);
    }

    public override void Die()
    {
        PlayerGameMechanics.instance.Die();
    }

}
