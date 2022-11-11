using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSelector : MonoBehaviour
{
    [SerializeField]GameObject giftList;
    GameObject curGift;


    private void Start()
    {
        FindObjectOfType<StartGift>().SelectGift();
    }

    public void ShowGiftList()
    {
        giftList.SetActive(true);
    }

    void HideGiftList()
    {
        giftList.SetActive(false);

    }

    public void SetCurGift(GameObject gift)
    {
        curGift = gift;
        HideGiftList();
    }

    public void SubmitData()
    {
        GetComponentInParent<HeroCreationScreen>().gift = curGift;
    }
}
