using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarManagement : MonoBehaviour
{
    Slider slider;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        slider = GetComponent<Slider>();
        slider.maxValue = player.GetComponent<PhisicalEntity>().maxHp;
        slider.value = slider.maxValue;
    }



    void Update()
    {

    }

    public void ChangeSliderValue(int curVal)
    {
        slider.value = curVal;
    }
}
