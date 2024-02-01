using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonEquip : MonoBehaviour
{
    public Image icon;
    public Text itemNameText;
    public Button equipButton; // Tambahkan tombol equip pada Unity dan hubungkan ke sini

    private string equippedItemName;

    public void SetItem(ItemData item)
    {
        itemNameText.text = item.itemName;
        icon.sprite = ItemManager.instance.GetIcon(item);

        equippedItemName = item.itemName;

        // Aktifkan tombol equip
        equippedItemName = item.itemName; // Assign nama item langsung ke variabel
        equipButton.interactable = true;
    }

    public void EquipItem()
    {
        // TODO: Implementasikan logika untuk mengequip item
        // Misalnya, kirim perintah ke PlayerController untuk mengequip item ini
        // atau atur item ini sebagai item yang aktif pada pemain

        // Contoh:
        // PlayerController.Instance.EquipItem(equippedItemName);

        // Matikan tombol equip setelah item di-equip
        equipButton.interactable = false;
    }
}
