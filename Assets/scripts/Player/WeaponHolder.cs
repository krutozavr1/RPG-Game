using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public static WeaponHolder instance;
    GameObject curWeapon;
    bool hasWeapon = false;

    void Start()
    {
        instance = this;
    }

    public void PickNewWeapon(GameObject weapon)
    {
        if(hasWeapon)
        {
            DropCurrentWeapon();
        }
        curWeapon = weapon;
        curWeapon.transform.SetParent(transform);
        curWeapon.transform.position = Vector2.zero;
        hasWeapon = true;                           
        ActivateWeapon();
    }
    private void ActivateWeapon()
    {
        curWeapon.GetComponent<Weapon>().enabled = true;
        curWeapon.GetComponent<PlayerWeapon>().enabled = true;
    }

    private void DropCurrentWeapon()
    {
        curWeapon.GetComponent<Weapon>().enabled = false;
        curWeapon.GetComponent<PlayerWeapon>().enabled = false;
        hasWeapon = false;
        curWeapon.GetComponent<InventoryItem>().ReturnToInventory();
    }

}
