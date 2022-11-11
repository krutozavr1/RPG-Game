using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySecondaryWeapon : InventoryItem
{
    public override void UseItem()
    {
        FindObjectOfType<SecondaryWeaponHolder>().AssignNewWeapon(gameObject, GetComponent<SecondaryWeapon>().coolDown, GetComponent<SecondaryWeapon>().maxCnt);
        FindObjectsOfType<InventoryInfoWindow>(true)[0].SetSecWeaponImage(GetComponent<SpriteRenderer>().sprite);
        alreadyPickedUp = true;

    }
}
