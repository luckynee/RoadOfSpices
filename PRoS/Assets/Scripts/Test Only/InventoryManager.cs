using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryManager : ScriptableObject
{
    public List<ItemData> items = new ();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

// Fungsi untuk menambah item ke inventori
    public void AddItem(ItemData item)
    {
        items.Add(item);

        // Panggil callback untuk memberi tahu perubahan pada inventori
        onItemChangedCallback?.Invoke();
    }

// Fungsi untuk menghapus item dari inventori
    public void RemoveItem(ItemData item)
    {
        items.Remove(item);

        // Panggil callback untuk memberi tahu perubahan pada inventori
        onItemChangedCallback?.Invoke();
    }

    // Fungsi untuk mengecek apakah item sudah ada di inventori
    public bool HasItem(ItemData item)
    {
        return items.Contains(item);
    }
}