using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    public Sprite sprite; // Change this line
    public GameObject itemObject;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();

        // Add null check to avoid potential issues
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager component not found on 'Inventory Canvas' object.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (inventoryManager != null)
            {
                inventoryManager.AddItem(itemName, quantity, sprite);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("InventoryManager is null. Cannot add item.");
            }
        }
    }
}
