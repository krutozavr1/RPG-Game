using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopStand : MonoBehaviour
{
    GameObject item;
    ShopItem shopItem;
    ShopDescriptionScreen descriptionScreen;
    int itemPrice;


    public void AssignAllData(GameObject itemPrefab)
    {
        item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        item.transform.SetParent(transform);
        shopItem = item.GetComponent<ShopItem>();
        GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemPrice = shopItem.shopCost;
        descriptionScreen = FindObjectsOfType<ShopDescriptionScreen>(true)[0];

    }


    public void BuyItem()
    {
        if(MoneyCount.instance.curScore >= itemPrice)
        {
            item.gameObject.GetComponent<InventoryItem>().AddItemToInventory();
            MoneyCount.instance.ChangeMoneyScore(-itemPrice);
            Destroy(gameObject);
        }
    }

    public void ShowItemWindow()
    {
        descriptionScreen.gameObject.SetActive(true);
        descriptionScreen.SetDescriptionScreen(shopItem.shopSprite, shopItem.shopCost, shopItem.description, this) ;
    }

}
