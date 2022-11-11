using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

public class TrowingAxe : Weapon
{

    [HideInInspector]public bool withPlayer = true, returningToPlayer = false, isCharged = false;
    Vector3 dirToThePlayer;
    float  normalSpeed = 9, returningSpeed, speed = 9, timePressed = 0f, enemyPullForce = 80f;
    Rigidbody2D rb;
    [SerializeField]SliderController slider;
    [SerializeField] Vector3 baseScale;
    public int dmg, normalDmg;


    protected override void SetDifferentVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        baseScale = transform.localScale;
        ResetSlider();
    }

    protected override void Update()
    {
        dirToThePlayer = (playerMove.transform.position - transform.position).normalized;
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("direction", Mathf.Sign(rb.velocity.x));
        if (returningToPlayer)
        {
            FlyToPlayer();
        }
        if((Mouse.current.leftButton.isPressed) && (withPlayer))
        {
            timePressed += Time.deltaTime;
            if(timePressed >= 1)
            {
                UpdateSlider(timePressed);
            }
        }
        if ((Mouse.current.leftButton.wasReleasedThisFrame))
        {
            if(withPlayer)
            {
                ThrowAxe();
            }
            else
            {
                CallAxeBack();
            }
        }
    }

    public override void OnAttack(InputValue value)
    {
        
    }

    void ThrowAxe()
    {
        CalculeteAdditionalSpeedAndDmg();
        transform.parent = null;
        withPlayer = false;
        rb.velocity = GetDirectionVector() * speed;
        ResetSlider();
    }

    private Vector2 GetDirectionVector()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10;
        Vector2 direction = (Camera.main.ScreenToWorldPoint(mousePos) - transform.position).normalized;
        return direction;
    }

    void CalculeteAdditionalSpeedAndDmg()
    {
        timePressed = Mathf.Clamp(timePressed, 1, 2);
        if(timePressed >= 1.5f)
        {
            isCharged = true;
        }
        speed = normalSpeed;
        dmg = normalDmg;
        dmg = (int)(normalDmg * timePressed);
        speed = (int)(speed * timePressed);
        timePressed = 0;
    }

    void CallAxeBack()
    {
        if(transform.parent != null)
        {
            transform.parent.GetComponent<Rigidbody2D>().AddForce(enemyPullForce * dirToThePlayer, ForceMode2D.Impulse);
            transform.parent = null;
        }
        speed *= 1.4f;
        returningToPlayer = true;
    }

    void FlyToPlayer()
    {
        rb.velocity = dirToThePlayer * speed;
    }



    void CatchAxe()
    {
        ResetTransform();
        ResetVariables();
        rb.velocity = Vector2.zero;
        
    }


    private void ResetVariables()
    {
        returningToPlayer = false;
        withPlayer = true;
        isCharged = false;
    }

    private void ResetTransform()
    {
        transform.SetParent(playerMove.transform.GetChild(0), true);
        transform.localScale = baseScale;
        transform.localPosition = startPos;
        transform.localRotation = Quaternion.Euler(startRot);
    }

    void UpdateSlider(float val)
    {
        slider.gameObject.SetActive(true);
        slider.SetCurVal(Mathf.Clamp(val, 1, 2));
    }

    void ResetSlider()
    {
        slider.SetCurVal(1);
        slider.gameObject.SetActive(false);
    }

    public void Stop(Transform newParent)
    {
        if (!returningToPlayer)
        {
            rb.velocity = Vector2.zero;
            transform.SetParent(newParent);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player") && (!withPlayer) && (returningToPlayer))
        {
            CatchAxe();
        }
    }

}
