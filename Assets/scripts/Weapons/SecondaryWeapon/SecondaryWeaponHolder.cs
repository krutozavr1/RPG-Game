using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryWeaponHolder : MonoBehaviour
{
    bool canBeUsed = true;
    float coolDown, maxCnt;
    float timePassed = 0f;
    GameObject secondaryWeapon;
    List<GameObject> weapons = new List<GameObject>();  

    void Start()
    {

    }

    void Update()
    {
        if ((timePassed >= coolDown) && (Mouse.current.rightButton.isPressed))
        {
            UseSecondaryWeapon();
            timePassed = 0;
        }
        timePassed += Time.deltaTime;
    }

    public void AssignNewWeapon(GameObject newWeapon, float cd, float maxCount)
    {
        secondaryWeapon = newWeapon;
        coolDown = cd;
        maxCnt = maxCount;
    }

    private void UseSecondaryWeapon()
    {
        if(weapons.Count >= maxCnt)
        {
            if (weapons.Count > 0)
            {
                Destroy(weapons[0]);    
                weapons.RemoveAt(0);

            }
        }
        if(secondaryWeapon != null)
        {

            GameObject weapon = Instantiate(secondaryWeapon, transform.position, Quaternion.identity);
            weapons.Add(weapon);
            weapon.GetComponent<SecondaryWeapon>().enabled = true;
        }
    }
}
