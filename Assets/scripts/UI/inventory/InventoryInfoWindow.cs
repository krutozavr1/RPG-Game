using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoWindow : MonoBehaviour
{
    [SerializeField] Image playerSkin, weapon, secWeapon;
    [SerializeField] GameObject soulCnt;
    [SerializeField] Vector3 normalPos, inventoryPos;

    private void OnEnable()
    {
        soulCnt.GetComponent<RectTransform>().anchoredPosition = inventoryPos;
    }

    private void OnDisable()
    {
        soulCnt.GetComponent<RectTransform>().anchoredPosition = normalPos;

    }

    public void SetPlayerImage(Sprite sprite)
    {
        playerSkin.sprite = sprite;
    }

    public void SetWeaponImage(Sprite sprite)
    {
        weapon.sprite = sprite;
    }
    public void SetSecWeaponImage(Sprite sprite)
    {
        secWeapon.sprite = sprite;
    }
}
