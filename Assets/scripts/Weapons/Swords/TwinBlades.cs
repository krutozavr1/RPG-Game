using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBlades : Weapon
{

    bool isBackSwing = false;
    protected override void SetDifferentVariables()
    {
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (cd <= timePassed) && (!isBackSwing))
        {
            anim.SetTrigger("Swing");
            //StartCoroutine(playerMove.LowerSpeed(.8f));
            timePassed = 0;
            isBackSwing = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (cd <= timePassed) && (isBackSwing))
        {
            anim.SetTrigger("BackSwing");
            //StartCoroutine(playerMove.LowerSpeed(.8f));
            timePassed = 0;
            isBackSwing = false;
        }

        timePassed += Time.deltaTime;
    }


}
