using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartGift : MonoBehaviour
{
    [SerializeField] GameObject gift;
    [SerializeField]Sprite image;
    [SerializeField]string description;

    void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = description;
        GetComponentInChildren<Image>().sprite = image;
    }

    public void SelectGift()
    {
        GetComponentInParent<HeroCreationScreen>().SetImage(image, "gift");
        GetComponentInParent<GiftSelector>().SetCurGift(gift);
    }

}
