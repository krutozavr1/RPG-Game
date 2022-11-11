using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField]GameObject weaponShelf, secondaryWeaponShelf, bonusShelf, usableItemsShelf;
    private void OnEnable()
    {
        OpenNewShelf(weaponShelf);
    }

    public void AddCellToInventory(InventoryItem.Type type, GameObject cell)
    {
        switch (type)
        {
            case InventoryItem.Type.weapon: cell.transform.SetParent(weaponShelf.transform, false);break;
            case InventoryItem.Type.secondoryWeapon: cell.transform.SetParent(secondaryWeaponShelf.transform, false); break;
            case InventoryItem.Type.usableItem: cell.transform.SetParent(usableItemsShelf.transform, false); break;
            case InventoryItem.Type.bonus: cell.transform.SetParent(bonusShelf.transform, false); break;
        }

    }

    public void OpenNewShelf(GameObject shelf)
    {
        weaponShelf.SetActive(false);
        secondaryWeaponShelf.SetActive(false);
        bonusShelf.SetActive(false);
        usableItemsShelf.SetActive(false);
        shelf.SetActive(true);
    }

}
