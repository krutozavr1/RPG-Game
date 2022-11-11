using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    public void SetMaxValue(int maxVal)
    {
        slider.maxValue = maxVal;
        slider.value = maxVal;
    }

    public void SetCurVal(float curVal)
    {
        slider.value = curVal;
    }

    public void ChangeSliderVal(float val)
    {
        slider.value += val;
    }
}
