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

    public void EmptyItem() 
    {
        //MNyalain image emprt
        imageEmpty.SetActive(true);

        isFill = false;

    }

    public void AddItem(string itemName) 
    {
        textItem.text=itemName;
        imgIcon.sprite = ItemManager.instance.GetIcon(itemName);

        //Matiin image emprt
        imageEmpty.SetActive(false);

        isFill = true;
    }
}
