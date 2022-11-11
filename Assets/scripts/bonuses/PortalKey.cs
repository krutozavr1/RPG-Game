using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : InventoryBonus
{
    bool playerCanUsePortals = false;

    public bool PlayerFoundPortalKey
    {
        get
        {
            return playerCanUsePortals;
        }
    }
    public override void UseItem()
    {
        playerCanUsePortals = true;
    }
}
