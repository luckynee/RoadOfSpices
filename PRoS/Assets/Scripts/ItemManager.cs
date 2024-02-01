using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public void Awake()
    {
        instance = this;
    }

    // Mengambil ikon dari ItemData
    public Sprite GetIcon(ItemData item)
    {
        return item.itemIcon;
    }
}

