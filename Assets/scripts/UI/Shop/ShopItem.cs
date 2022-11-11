using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public string description;
    public int shopCost;
    public Sprite shopSprite;
    void Start()
    {
        shopSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        
    }
}
