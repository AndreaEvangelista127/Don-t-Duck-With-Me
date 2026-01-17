using System;
using UnityEngine;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenInsanityDecrease;

    [SerializeField]
    private float amountToReduce;

    [SerializeField]
    private Slider insanitySlider;

    private float insanity = 100.0f;
    private float elapsedTime = 0;  

    public event Action<float> OnInsanityChanged;
    public event Action OnInsanityZero;


    private void Awake()
    {
        insanity = 100.0f;
        RefreshInsanity();
    }
    public void AddInsanity(float value)
    {
        insanity = Mathf.Clamp(insanity + value, 0.0f, 100.0f);
        OnInsanityChanged?.Invoke(value);
        Debug.Log("Insanity: " + insanity);
        RefreshInsanity();
    }

    public void ReduceInsanity(float value)
    {
        insanity = Mathf.Clamp(insanity - value, 0.0f, 100.0f);
        OnInsanityChanged?.Invoke(value);
        Debug.Log("Insanity: " + insanity);
        if (insanity == 0)
        {
            OnInsanityZero?.Invoke();   
        }
        RefreshInsanity();
    }
    private void RefreshInsanity()
    {
        insanitySlider.value = insanity/100.0f;    
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeBetweenInsanityDecrease)
        {
            ReduceInsanity(amountToReduce);
            elapsedTime = 0.0f;
        }
    }
}
