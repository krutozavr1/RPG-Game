using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PhisicalEntity
{
    [SerializeField]Trigger trigger;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Die()
    {
        trigger.ActivateEvent();
        anim.SetBool("isOn", true);
    }
}
