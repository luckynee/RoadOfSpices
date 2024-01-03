using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public static UIInventory instance;

    
    public BtnInventoryItem[] btns;

    void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EmptyAllButtons();
    }

    void EmptyAllButtons() 
    {
        foreach(BtnInventoryItem item in btns) 
        {
            item.EmptyItem();
        }
    }


    public void AddItemToUI(string itemName) 
    {
        //Check 'btns' seng belum di isi

        // int jumlahBtn = btns.Lenght;
        for(int i = 0; i < 10; i++)
        {
            if(!btns[i].isFill) 
            {
                btns[i].AddItem(itemName);
                break;
            }
        }
    }

    public void RemoveItemFromUI(string itemName)
    {
        // Cari button yang berisi item dengan nama yang sesuai dan kosongkan
        foreach (BtnInventoryItem btn in btns)
        {
            if (btn.isFill && btn.textItem.text == itemName)
            {
                btn.EmptyItem();
                break; // Keluar dari loop setelah menemukan dan mengosongkan button
            }
        }
    }

}
