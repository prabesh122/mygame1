using Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    private Gradient gradient;
    private Image fill;

    public Slider Slider { get => slider; set => slider = value; }
    public Gradient Gradient { get => gradient; set => gradient = value; }
    public Image Fill { get => fill; set => fill = value; }

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;

        Fill.color = Gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        Slider.value = health;

        Fill.color = Gradient.Evaluate(Slider.normalizedValue);
    }

}