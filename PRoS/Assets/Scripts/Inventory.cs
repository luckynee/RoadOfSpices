using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new();

    public int itemPala;
    public int itemTulang;
    public int itemMutiara;
    public int itemKompas;
    public int itemBlanket;
    public int itemKerang;
    public int itemKetel;
    public int itemUndanganKerajaan;
    public int itemPemetikPala;
    public int itemOpium;
    public int itemMiras;
    public int itemKoinEmas;
    public int itemPalaBuruk;
    public int itemPalaMentah;
    public int itemPalaBagus;
    public int itemSilkDress;
    public int itemKeySlave;
    public int itemKeyBarn;


    public void AddItem(string item)
    {
        items.Add(item);
        if (item == "Pala")
        {
            itemPala++;
        }
        else if (item == "Tulang")
        {
            itemTulang++;
        }
        else if (item == "Mutiara")
        {
            itemMutiara++;
        }
        else if (item == "Kompas")
        {
            itemKompas++;
        }
        else if (item == "Blanket")
        {
            itemBlanket++;
        }
        else if (item == "Kerang")
        {
            itemKerang++;
        }
        else if (item == "Ketel")
        {
            itemKetel++;
        }
        else if (item == "UndanganKerajaan")
        {
            itemUndanganKerajaan++;
        }
        else if (item == "PemetikPala")
        {
            itemPemetikPala++;
        }
        else if (item == "Opium")
        {
            itemOpium++;
        }
        else if (item == "Miras")
        {
            itemMiras++;
        }
        else if (item == "KoinEmas")
        {
            itemKoinEmas++;
        }
        else if (item == "PalaBuruk")
        {
            itemPalaBuruk++;
        }
        else if (item == "PalaMentah")
        {
            itemPalaMentah++;
        }
        else if (item == "PalaBagus")
        {
            itemPalaBagus++;
        }
        else if (item == "SilkDress")
        {
            itemSilkDress++;
        }
        else if (item == "KeySlave")
        {
            itemKeySlave++;
        }
        else if (item == "KeyBarn")
        {
            itemKeyBarn++;
        }

        //tampilkan di ui

        UIInventory.instance.AddItemToUI(item);
    }

    public void SubtractItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log("APA KAH KE SINI");
        }

        if (item == "Pala")
        {
            itemPala--;
        }
        else if (item == "Tulang")
        {
            itemTulang--;
        }
        else if (item == "Mutiara")
        {
            itemMutiara--;
        }
        else if (item == "Kompas")
        {
            itemKompas--;
        }
        else if (item == "Blanket")
        {
            itemBlanket--;
        }
        else if (item == "Kerang")
        {
            itemKerang--;
        }
        else if (item == "Ketel")
        {
            itemKetel--;
        }
        else if (item == "UndanganKerajaan")
        {
            itemUndanganKerajaan--;
        }
        else if (item == "PemetikPala")
        {
            itemPemetikPala--;
        }
        else if (item == "Opium")
        {
            itemOpium--;
        }
        else if (item == "Miras")
        {
            itemMiras--;
        }
        else if (item == "KoinEmas")
        {
            itemKoinEmas--;
        }
        else if (item == "PalaBuruk")
        {
            itemPalaBuruk--;
        }
        else if (item == "PalaMentah")
        {
            itemPalaMentah--;
        }
        else if (item == "PalaBagus")
        {
            itemPalaBagus--;
        }
        else if (item == "SilkDress")
        {
            itemSilkDress--;
        }
        else if (item == "KeySlave")
        {
            itemKeySlave--;
        }
        else if (item == "KeyBarn")
        {
            itemKeyBarn--;
        }

        //tampilkan di ui
        UIInventory.instance.RemoveItemFromUI(item);

        // Periksa apakah pemain telah menyelesaikan quest dengan NPC yang membutuhkan item ini
        //CheckQuestStatus(item);
    }

    public bool CheckItemHave(string itemName)
    {
        switch (itemName)
        {
            case "Pala":
                if (itemPala >= 1)
                {
                    return true;
                }
                break;

            case "Tulang":
                if (itemTulang >= 1)
                {
                    return true;
                }
                break;

            case "Mutiara":
                if (itemMutiara >= 1)
                {
                    return true;
                }
                break;

            case "Kompas":
                if (itemKompas >= 1)
                {
                    return true;
                }
                break;

            case "Blanket":
                if (itemBlanket >= 1)
                {
                    return true;
                }
                break;

            case "Kerang":
                if (itemKerang >= 1)
                {
                    return true;
                }
                break;

            case "Ketel":
                if (itemKetel >= 1)
                {
                    return true;
                }
                break;

            case "UndanganKerajaan":
                if (itemUndanganKerajaan >= 1)
                {
                    return true;
                }
                break;

            case "PemetikPala":
                if (itemPemetikPala >= 1)
                {
                    return true;
                }
                break;

            case "Opium":
                if (itemOpium >= 1)
                {
                    return true;
                }
                break;

            case "Miras":
                if (itemMiras >= 1)
                {
                    return true;
                }
                break;

            case "KoinEmas":
                if (itemKoinEmas >= 1)
                {
                    return true;
                }
                break;

            case "PalaBuruk":
                if (itemPalaBuruk >= 1)
                {
                    return true;
                }
                break;

            case "PalaMentah":
                if (itemPalaMentah >= 1)
                {
                    return true;
                }
                break;

            case "PalaBagus":
                if (itemPalaBagus >= 1)
                {
                    return true;
                }
                break;

            case "SilkDress":
                if (itemSilkDress >= 1)
                {
                    return true;
                }
                break;

            case "KeySlave":
                if (itemKeySlave >= 1)
                {
                    return true;
                }
                break;

            case "KeyBarn":
                if (itemKeyBarn >= 1)
                {
                    return true;
                }
                break;
        }
        return false;
    }
}
