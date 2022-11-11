using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    HitTrigger weapon;

    void OnEnable()
    {
        weapon = GetComponentsInChildren<HitTrigger>(true)[0];
        ApplyAdditionalDmg(FindObjectOfType<Player>().dmg);
    }

    public void ApplyAdditionalDmg(int val)
    {
        weapon.dmg = (int)(weapon.dmg * (1 + val / 10f));
    }
}
