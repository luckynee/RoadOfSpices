using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour
{
    
    public List<ItemData> items;
    public event EventHandler OnAddItem; 
    private void Update()
    {
        Debug.Log(items.Count);
    }
    private void Start()
    {
        items = new List<ItemData>();
    }

    public void AddItem(ItemData itemData)
    {


        if (itemData != null)
        {
            OnAddItem?.Invoke(this, EventArgs.Empty);
            items.Add(itemData);
            Debug.Log("Item added: " + itemData.itemName);
            // Tampilkan di UI
            UIInventory.instance.AddItemToUI(itemData);
        }
        
    }

    public void RemoveItem(ItemData itemData)
    {
        items.Remove(itemData);
        UIInventory.instance.RemoveItemFromUI(itemData);
    }

    public bool HasItem(ItemData itemData)
    {
        return items.Contains(itemData);
    }

    
}
