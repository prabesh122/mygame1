using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryPanel;
    public GameObject itemPrefab;

    private void Start()
    {
        inventoryPanel.SetActive(false);
        inventory.onItemChangedCallback += UpdateUI; // Subscribe to the onItemChangedCallback event
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void UpdateUI()
    {
        // Remove old items
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Add new items
        foreach (Item item in inventory.items)
        {
            GameObject itemUI = Instantiate(itemPrefab, inventoryPanel.transform);
            itemUI.GetComponent<Image>().sprite = item.sprite;
            itemUI.GetComponentInChildren<Text>().text = item.name; // Change itemName to name
        }
    }
}
