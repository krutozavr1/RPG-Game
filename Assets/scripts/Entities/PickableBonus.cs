using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBonus : MonoBehaviour
{
    [SerializeField] GameObject decriptionBox;
    [SerializeField] BoxCollider2D itemTrigger;
    bool canBePicked = false, isPicked = false;

    void Update()
    {
        if ((canBePicked) && (Input.GetKeyDown(KeyCode.E)))
        {
            isPicked = true;
            PickWeapon();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (!isPicked))
        {
            ShowDecriptionBox();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HideDecriptionBox();
        }
    }

    private void ShowDecriptionBox()
    {
        decriptionBox.SetActive(true);
        canBePicked = true;
        Tutorial.instance.Activate();
    }

    private void HideDecriptionBox()
    {
        decriptionBox.SetActive(false);
        canBePicked = false;
        Tutorial.instance.Deactivate();
    }

    private void PickWeapon()
    {
        HideDecriptionBox();
        WeaponHolder.instance.PickNewWeapon(gameObject);
        itemTrigger.enabled = false;
        ActivateWeapon();
    }



    private void ActivateWeapon()
    {
        GetComponent<Weapon>().enabled = true;
    }

    public void DropWeapon()
    {
        isPicked = false;
        GetComponent<Weapon>().enabled = false;
        itemTrigger.enabled = true;

    }
}
