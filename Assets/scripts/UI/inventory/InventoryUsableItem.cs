using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUsableItem : InventoryItem
{
    public override void UseItem()
    {
        GetComponent<UsableItem>().UseItem();
        Destroy(cell); 
    }
}
