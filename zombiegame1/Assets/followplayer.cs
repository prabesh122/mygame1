using Mechanics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Slider slider; // Reference to the UI slider
    public Vector3 offset; // Offset position of the health bar

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = player.GetComponent<Health>().maxHealth; // Set the max value of the slider to the player's max health
        slider.value = player.GetComponent<Health>().currentHealth; // Set the current value of the slider to the player's current health
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.GetComponent<Health>().currentHealth; // Update the slider's value to the player's current health

        // Update the position of the health bar to follow the player
        Vector3 worldPos = new Vector3(player.position.x, player.position.y, player.position.z) + offset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        slider.transform.position = screenPos;
    }
}
