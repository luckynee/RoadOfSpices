using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryScript : ScriptableObject
{
    public List<ItemData> items = new();
}
