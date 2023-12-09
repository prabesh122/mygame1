using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Delegate for the OnItemChanged event
    public delegate void OnItemChanged();
    // Event that gets called whenever an item is added or removed
    public OnItemChanged onItemChangedCallback;

    // List of items in the inventory
    public List<Item> items = new List<Item>();

    // Function to add an item to the inventory
    public void Add(Item item)
    {
        items.Add(item);

        // Invoke the OnItemChanged event
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    // Function to remove an item from the inventory
    public void Remove(Item item)
    {
        items.Remove(item);

        // Invoke the OnItemChanged event
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
