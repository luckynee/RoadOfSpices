using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public static PlayerQuest instance;

    public string activeQuestItem;

    void Awake()
    {
        instance = this;
    }

    public void AddItemRequested(ItemData itemData)
    {
        activeQuestItem = itemData.itemName; // Ganti menjadi itemData.itemName
    }
}
