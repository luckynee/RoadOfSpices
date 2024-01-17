using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class ItemInventory : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite visual;

    public int nameItem;
    public int itemFunction;
}
