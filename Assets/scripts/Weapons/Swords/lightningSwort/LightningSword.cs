using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightningSword : Weapon
{
    [SerializeField]GameObject lightning;
    

    void OnAttack(InputValue value)
    {
        if (cd <= timePassed)
        {
            anim.SetTrigger("Swing");
            SummonLightning();
            timePassed = 0;
        }
    }

    private void SummonLightning()
    {
        Vector2 strikePos = SetPositionOfLightning();
        lightning.GetComponent<Lightning>().Strike(strikePos);
    }

    private Vector2 SetPositionOfLightning()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
