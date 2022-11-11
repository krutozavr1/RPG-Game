using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryItem : MonoBehaviour
{
    [SerializeField] GameObject inventoryCellPrefab;
    [SerializeField] Type type;
    public string description;
    public bool alreadyPickedUp = false, canBePickedUp = false;
    protected GameObject cell;


    public enum Type {weapon, secondoryWeapon, bonus, usableItem };

    private void Update()
    {
        if ((Keyboard.current.eKey.isPressed) && (canBePickedUp))
        {
            AddItemToInventory();
        }
    }

    public virtual void AddItemToInventory()
    {
        alreadyPickedUp = true;
        cell = Instantiate(inventoryCellPrefab, transform.position, Quaternion.identity);
        cell.GetComponent<InventoryCell>().CreateNewCell(gameObject, type);
        transform.SetParent(cell.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !alreadyPickedUp)
        {
            Tutorial.instance.Activate();
            canBePickedUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Tutorial.instance.Deactivate();
            canBePickedUp = false;
        }
    }

    public virtual void UseItem()
    {
    }

    public void ReturnToInventory()
    {
        cell.GetComponent<InventoryCell>().ReturnItemToInventory();
    }
}
