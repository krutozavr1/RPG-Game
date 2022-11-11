using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickableWeapon : MonoBehaviour
{
    [SerializeField]GameObject decriptionBox;
    [SerializeField] BoxCollider2D itemTrigger;
    bool canBePicked = false, isPicked = false;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        itemTrigger.enabled = true;
    }

    void Update()
    {
        if((canBePicked) && (Keyboard.current.eKey.isPressed))
        {
            isPicked = true;
            PickWeapon();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player") && (!isPicked) && (this.enabled))
        {
            ShowDecriptionBox();
            canBePicked = true;
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
        GetComponent<PlayerWeapon>().enabled = true;
    }

    public void DropWeapon()
    {
        isPicked = false;
        GetComponent<Weapon>().enabled = false;
        GetComponent<PlayerWeapon>().enabled = false;
        itemTrigger.enabled = true;

    }
}
