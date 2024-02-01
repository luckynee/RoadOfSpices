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


    public void AddItemToUI(ItemData item) 
    {
        //Check 'btns' seng belum di isi

        // int jumlahBtn = btns.Lenght;
        for(int i = 0; i < btns.Length; i++)
        {
            if(!btns[i].isFill) 
            {
                btns[i].AddItem(item);
                break;
            }
        }
    }

    public void RemoveItemFromUI(ItemData item)
    {
        BtnInventoryItem btn = System.Array.Find(btns, b => b.isFill && b.AssociatedItemData == item);
        if (btn != null)
        {
            btn.EmptyItem();
        }
    }

    //public void RemoveItemFromUI(ItemData item)
    //{
        // Cari button yang berisi item dengan nama yang sesuai dan kosongkan
        //foreach (BtnInventoryItem btn in btns)
        //{
            //if (btn.isFill && btn.textItem.text == itemName)
            //{
               // btn.EmptyItem();
               // break; // Keluar dari loop setelah menemukan dan mengosongkan button
            //}
        //}
    //}

}
