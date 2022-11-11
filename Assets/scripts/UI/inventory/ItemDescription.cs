using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescription : MonoBehaviour
{

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void ShowDescription(string description)
    {
        gameObject.SetActive(true);
        text.text = description;
    }

    public void HideDescription()
    {
        gameObject.SetActive(false);
    }
}
