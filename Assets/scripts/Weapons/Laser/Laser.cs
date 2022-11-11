using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    [SerializeField] protected GameObject beam;

    public virtual void StartLasering(bool shouldStopItself = false)
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Laser");
        if(shouldStopItself)
        {
            Invoke(nameof(FinishLasering), 3);
        }
    }

    private void ActivateBeam()
    {
        beam.SetActive(true);
    }

    public virtual void FinishLasering()
    {
        beam.SetActive(false);
        gameObject.SetActive(false);
    }


}
