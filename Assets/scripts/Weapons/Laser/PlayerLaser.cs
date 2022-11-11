using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLaser : Laser
{

    private new void Update()
    {
        transform.right = GetDirectionVector();
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartLasering();
        }
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            FinishLasering();
        }
    }

  

    private Vector2 GetDirectionVector()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10;
        Vector2 direction = (Camera.main.ScreenToWorldPoint(mousePos) - transform.position).normalized;
        return direction;
    }

    public override void StartLasering(bool shouldStopItself = false)
    {
        anim.SetBool("isLasering", true);

    }

    public override void FinishLasering()
    {
        anim.SetBool("isLasering", false);
        beam.SetActive(false);
    }
}
