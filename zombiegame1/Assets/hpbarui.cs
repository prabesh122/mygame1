using Mechanics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar1 : MonoBehaviour
{
    public Slider slider; // Reference to the UI slider
    public Health player; // Reference to the player

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = player.maxHealth; // Set the max value of the slider to the player's max health
        slider.value = player.currentHealth; // Set the current value of the slider to the player's current health
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.currentHealth; // Update the slider's value to the player's current health
    }
}
