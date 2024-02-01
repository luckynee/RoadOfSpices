using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnInventoryItem : MonoBehaviour
{
    public bool isFill;
    public GameObject imageEmpty;
    public TextMeshProUGUI textItem;
    public Image imgIcon;

    // Add this property to store the associated ItemData
    public ItemData AssociatedItemData { get; private set; }

    public void EmptyItem() 
    {
        //MNyalain image emprt
        imageEmpty.SetActive(true);
        isFill = false;

    }

    public void AddItem(ItemData itemData) 
    {
        textItem.text = itemData.itemName;  // Use itemData instead of ItemData
        imgIcon.sprite = itemData.itemIcon;

        // Store the associated ItemData
        AssociatedItemData = itemData;

        //Matiin image emprt
        imageEmpty.SetActive(false);
        isFill = true;
    }
}
