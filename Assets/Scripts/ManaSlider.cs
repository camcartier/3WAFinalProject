using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSlider : MonoBehaviour
{
    public Slider _slider;

    public void SetMaxMana(float mana)
    {
        _slider.maxValue = mana;
        _slider.value = mana;
    }

    public void SetMana(float mana)
    {
        _slider.value = mana;
    }
}
