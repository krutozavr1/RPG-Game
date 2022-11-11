using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : UsableItem
{

    [SerializeField]
    int hpQuaters;




    public override void UseItem()
    {
        PlayerHearts.instance.RestoreSomeHealth(hpQuaters);
        Destroy(gameObject);

    }
}
