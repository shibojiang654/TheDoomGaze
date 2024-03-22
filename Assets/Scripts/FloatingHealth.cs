using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealth : MonoBehaviour
{
    #region Update HP
    [SerializeField] private Slider slider;

    public void updateHealth(float currentValue, float maxValue) {
        slider.value = currentValue/maxValue;
    }
    #endregion
}
