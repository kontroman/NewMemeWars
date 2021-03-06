using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health HealthComponent;

    public GameObject player;

    private Image healthBarImage;

    float actualValue = 1f;
    float startValue = 1f;
    float displayValue = 1f;
    float timer = 0f;

    private void Awake()
    {
        HealthComponent = player.GetComponent<Health>();
        healthBarImage = GetComponent<Image>();
        healthBarImage.fillAmount = 1;
    }

    private void OnEnable()
    {
        HealthComponent.onHealthChangedAction += HealthChangerHandler;
    }

    private void OnDisable()
    {
        HealthComponent.onHealthChangedAction -= HealthChangerHandler;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        displayValue = Mathf.Lerp(startValue, actualValue, timer);
        healthBarImage.fillAmount = displayValue;
    }

    private void HealthChangerHandler(int _newHealth)
    {
        actualValue = _newHealth / 100f;
        startValue = healthBarImage.fillAmount;
        timer = 0f;
    }
}
