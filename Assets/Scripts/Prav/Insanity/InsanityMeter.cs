using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InsanityMeter : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenInsanityDecrease;

    [SerializeField]
    private float amountToReduce;

    [SerializeField]
    private Slider insanitySlider;

    [SerializeField]
    private Volume postProcess;

    private PlayerHealthComponent playerHealth;
    private Bloom playerBloom;
    private LensDistortion playerDistortion;
    private ChromaticAberration playerChromatic;
    private LiftGammaGain playerLift;

    private float insanity = 100.0f;
    private float elapsedTime = 0;  

    public event Action<float> OnInsanityChanged;
    public event Action OnInsanityZero;

    private void Awake()
    {
        insanity = 100.0f;
        RefreshInsanityUI();

        postProcess.profile.TryGet(out playerBloom);
        postProcess.profile.TryGet(out playerChromatic);
        postProcess.profile.TryGet(out playerDistortion);
        postProcess.profile.TryGet(out playerLift);

        playerHealth = GetComponent<PlayerHealthComponent>();
    } 
    public void AddInsanity(float value)
    {
        insanity = Mathf.Clamp(insanity + value, 0.0f, 100.0f);
        OnInsanityChanged?.Invoke(value);
        playerBloom.intensity.value += .1f;
        playerChromatic.intensity.value += .1f;
        playerDistortion.intensity.value += .1f;
        Debug.Log("Insanity: " + insanity);
        RefreshInsanityUI();
    }

    public void ReduceInsanity(float value)
    {
        insanity = Mathf.Clamp(insanity - value, 0.0f, 100.0f);
        OnInsanityChanged?.Invoke(value);

        if (insanity == 0)
        {
            OnInsanityZero?.Invoke();
            ClearEffects();
        }
        else
        {
            ReduceEffects(.1f);
            StartSmoothRandomize(.5f);
        }

        RefreshInsanityUI();
    }
    private void RefreshInsanityUI()
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
    public void StartSmoothRandomize(float duration)
    {
        StartCoroutine(RandomizeLiftRoutine(duration));
    }

    private IEnumerator RandomizeLiftRoutine(float duration)
    {
        float elapsed = 0f;

        Vector4 startGain = playerLift.gain.value;
        Vector4 startLift = playerLift.lift.value;
        Vector4 startGamma = playerLift.gamma.value;

        Vector4 targetGain = new Vector4(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), 0);
        Vector4 targetLift = new Vector4(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), 0);
        Vector4 targetGamma = new Vector4(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), 0);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            playerLift.gain.Interp(startGain, targetGain, t);
            playerLift.lift.Interp(startLift, targetLift, t);
            playerLift.gamma.Interp(startGamma, targetGamma, t);

            yield return null;
        }
    }

    private void ClearEffects()
    {
        playerHealth.Die();

        playerBloom.intensity.value = 0.0f;
        playerChromatic.intensity.value = 0f;
        playerDistortion.intensity.value = 0f;

        playerLift.gain.SetValue(new Vector4Parameter(new Vector4(0f,0f,0f,0f)));
        playerLift.lift.SetValue(new Vector4Parameter(new Vector4(0f,0f,0f,0f)));
        playerLift.gamma.SetValue(new Vector4Parameter(new Vector4(0f,0f,0f,0f)));

    }

    private void ReduceEffects(float intensity)
    {
        Debug.Log("Reducing effects");
        playerBloom.intensity.value = Mathf.Clamp(playerBloom.intensity.value - intensity, 0.0f, 100.0f);
        playerChromatic.intensity.value = Mathf.Clamp(playerChromatic.intensity.value - intensity, 0.0f, 100.0f);
        playerDistortion.intensity.value = Mathf.Clamp(playerDistortion.intensity.value - intensity, 0.0f, 100.0f);
    }
}
