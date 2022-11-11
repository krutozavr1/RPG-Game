using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBonus : InventoryItem
{
    [SerializeField] GameObject useButton;

    public override void AddItemToInventory()
    {
        base.AddItemToInventory();
        UseItem();
    }

    public override void UseItem()
    {
        GetComponent<Bonus>().UseBonus();
        Destroy(this);

    }


}
