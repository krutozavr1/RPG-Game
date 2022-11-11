using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject shopStandPrefab;
    [SerializeField]
    GameObject[] shelves;



    public void OrganizeShop(GameObject[] weapons, GameObject[] secWeapons, GameObject[] usables, GameObject[] bonuses)
    {
        ClearShop();
        GameObject[][] items = { weapons, secWeapons, usables, bonuses };
        for(int i = 0; i < 4; i++)
        {
            FillShelfWithItems(shelves[i], items[i]);
        }
    }

    private void ClearShop()
    {
        foreach(GameObject shelf in shelves)
        {
            while (shelf.transform.childCount > 0)
            {
                DestroyImmediate(shelf.transform.GetChild(0).gameObject);
            }
        }
    }

    private void FillShelfWithItems(GameObject shelf, GameObject[] items)
    {
        foreach(GameObject item in items)
        {
            GameObject stand = Instantiate(shopStandPrefab, transform.position, Quaternion.identity);
            stand.transform.SetParent(shelf.transform);
            stand.GetComponent<ShopStand>().AssignAllData(item);
        }
    }

    void OpenShop()
    {
        gameObject.SetActive(true);

    }

}
