using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health targetHealth;
    public Slider slider;

    void Update()
    {
        slider.maxValue = targetHealth.maxHealth;
        slider.value = targetHealth.currentHealth;
    }
}
