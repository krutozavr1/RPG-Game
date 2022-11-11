using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWeapon : InventoryItem
{
    public override void UseItem()
    {
        FindObjectsOfType<InventoryInfoWindow>(true)[0].SetWeaponImage(GetComponent<SpriteRenderer>().sprite);
        WeaponHolder.instance.PickNewWeapon(gameObject);
        alreadyPickedUp = true;

    }



    
}
