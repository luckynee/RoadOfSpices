using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    [TextArea]
    public string itemDescription;

    // Override ToString to return the itemName
    public override string ToString()
    {
        return itemName;
    }
}
