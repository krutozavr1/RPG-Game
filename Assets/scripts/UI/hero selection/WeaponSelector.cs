using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField]TextMeshProUGUI weaponName;
    int curCnt = 0;
    Sprite curImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowNextWeapon()
    {
        curCnt = (curCnt + 1) % weapons.Length;
        curImage = weapons[curCnt].GetComponent<SpriteRenderer>().sprite;
        GetComponentInParent<HeroCreationScreen>().SetImage(curImage, "weapon");
        weaponName.text = weapons[curCnt].name;
    }

    public void SubmitData()
    {
        GetComponentInParent<HeroCreationScreen>().weapon = weapons[curCnt];
    }
}
