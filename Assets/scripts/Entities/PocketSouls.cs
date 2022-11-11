using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketSouls : UsableItem
{
    public int value;
   

    public override void UseItem()
    {
        MoneyCount.instance.ChangeMoneyScore(value);
        Destroy(gameObject);
    }

    public void SetValue(int val)
    {
        value = val;
    }
}
