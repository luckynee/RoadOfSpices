using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonEquip : MonoBehaviour
{
    public Image icon;
    public Text itemName;
    public Button equipButton; // Tambahkan tombol equip pada Unity dan hubungkan ke sini

    private string equippedItemName;

    public void SetItem(string itemName)
    {
        this.itemName.text = itemName;
        icon.sprite = ItemManager.instance.GetIcon(itemName);

        equippedItemName = itemName;

        // Aktifkan tombol equip
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
