
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public void UpdateHealthBarValue(float currentValue, float maxValue)
    {
        _healthSlider.value = currentValue / maxValue;
    }




}
