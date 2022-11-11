using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGearAndStatTuner : MonoBehaviour
{
    public void SetGear(GameObject weapon, GameObject gift)
    {
        GameObject startWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        GameObject startGift = Instantiate(gift, transform.position, Quaternion.identity);
        startGift.GetComponent<InventoryItem>().AddItemToInventory();
        startWeapon.GetComponent<InventoryItem>().AddItemToInventory();
        startWeapon.GetComponent<InventoryWeapon>().UseItem();

    }

    public void SetStats(int hp, int speed, int dmg)
    {
        GetComponent<Player>().SetStat("hp", hp);
        GetComponent<Player>().SetStat("dmg", dmg);
        GetComponent<Player>().SetStat("speed", speed);
        Destroy(this);
    }

    
}
