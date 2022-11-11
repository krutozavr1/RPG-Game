using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    
    public Vector3 startPos, startRot;
    protected Animator anim;
    protected PlayerMovement playerMove;
    [SerializeField]
    public float cd, timePassed = 0;


    protected virtual void OnEnable()
    {
        TryGetComponent(out anim);
        timePassed = cd;
        playerMove = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();     
        transform.localPosition = startPos;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, transform.eulerAngles.z) + startRot; 
        SetDifferentVariables();
    }

    protected virtual void SetDifferentVariables()
    {

    }

    protected virtual void Update()
    {
        timePassed += Time.deltaTime;

    }

    public virtual void OnAttack(InputValue value)
    {
        if (cd <= timePassed)
        {
            Swing();
        }
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
        timePassed = 0;
    }

    protected virtual void SuperAbility()
    {

    }
}
