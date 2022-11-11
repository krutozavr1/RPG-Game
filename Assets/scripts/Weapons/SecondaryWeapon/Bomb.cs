using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : SecondaryWeapon
{

    private void OnEnable()
    {
        Explode();
    }

    void Update()
    {
        
    }

    private void Explode()
    {
        GetComponent<Animator>().SetTrigger("explode");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
