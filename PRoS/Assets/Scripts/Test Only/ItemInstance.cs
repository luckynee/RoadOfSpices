using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance : MonoBehaviour
{
    public ItemData itemType;
    public int condition;
    public int ammo;
    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        function = itemData.itemFunction;
    }
}
