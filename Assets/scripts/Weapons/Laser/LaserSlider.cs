using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSlider : MonoBehaviour
{

    Laser laser;
    Slider slider;
    float curVal;
    void Start()
    {
        laser = FindObjectOfType<Laser>();
        slider = GetComponent<Slider>();
        slider.maxValue = 100;
        slider.value = 100;
    }

    void Update()
    {

        if(!laser.gameObject.active)
        {
            gameObject.SetActive(false);
        }
    }
     
    public float CurValue
    {
        get
        {
            return curVal;
        }
    }


    public void ChangeSliderValue(float diff)
    {
        slider.value -= diff;
    }

}
