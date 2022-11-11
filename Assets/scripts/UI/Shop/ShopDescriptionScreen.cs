using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopDescriptionScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemPriceText, itemDescription;
    [SerializeField] Image itemImage;
    ShopStand curStand;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetDescriptionScreen(Sprite sprite, int price, string description, ShopStand stand)
    {
        itemImage.sprite = sprite;
        itemPriceText.text = price.ToString();
        itemDescription.text = description;
        curStand = stand;
    }

    public void BuyItem()
    {
        curStand.BuyItem();
        HideScreen();
    }

    public void HideScreen()
    {
        gameObject.SetActive(false);
    }
}
