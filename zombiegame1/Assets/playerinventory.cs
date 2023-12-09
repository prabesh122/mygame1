using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private Item nearbyItem;
    public float dropDistance = 2f; // This is the distance in front of the player where items will be placed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player is near an item"); // Debug statement for item detection
            nearbyItem = other.GetComponent<Item>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player is no longer near an item"); // Debug statement for item detection
            nearbyItem = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearbyItem != null)
        {
            Debug.Log("E key was pressed"); // Debug statement for 'E' key press
            inventory.items.Add(nearbyItem);
            nearbyItem.itemObject.SetActive(false);
            nearbyItem = null;
        }

        if (Input.GetKeyDown(KeyCode.P) && inventory.items.Count > 0)
        {
            Debug.Log("P key was pressed"); // Debug statement for 'P' key press
            Item item = inventory.items[0];
            inventory.items.RemoveAt(0);
            Vector3 dropPoint = transform.position + transform.forward * dropDistance; // Calculate the drop point
            item.itemObject.transform.position = dropPoint; // Set the item's position
            item.itemObject.SetActive(true);
        }
    }
}
