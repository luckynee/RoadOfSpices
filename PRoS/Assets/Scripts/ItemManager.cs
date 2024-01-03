using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager instance;

    public Sprite iconBlanket;
    public Sprite iconKompas;
    public Sprite iconTulang;
    public Sprite iconKerang;
    public Sprite iconKetel;
    public Sprite iconMutiara;
    public Sprite iconUndanganKerajaan;
    public Sprite iconPemetikPala;
    public Sprite iconOpium;
    public Sprite iconMiras;
    public Sprite iconKoinEmas;
    public Sprite iconPalaBuruk;
    public Sprite iconPalaMentah;
    public Sprite iconPalaBagus;
    public Sprite iconSilkDress;
    public Sprite iconKeySlave;
    public Sprite iconKeyBarn;

    void Awake() {
        instance = this;
    }


    public Sprite GetIcon(string itemName) 
    {
        switch(itemName) 
        {
            case "Blanket":
                return iconBlanket;
            break;

            case "Kompas":
                return iconKompas;
            break;

            case "Tulang":
                return iconTulang;
                break;

            case "Kerang":
                return iconKerang;
                break;

            case "Ketel":
                return iconKetel;
                break;

            case "Mutiara":
                return iconMutiara;
                break;

            case "UndanganKerajaan":
                return iconUndanganKerajaan;
                break;

            case "PemetikPala":
                return iconPemetikPala;
                break;

            case "Opium":
                return iconOpium;
                break;

            case "Miras":
                return iconMiras;
                break;

            case "KoinEmas":
                return iconKoinEmas;
                break;

            case "PalaBuruk":
                return iconPalaBuruk;
                break;

            case "PalaMentah":
                return iconPalaMentah;
                break;

            case "PalaBagus":
                return iconPalaBagus;
                break;

            case "SilkDress":
                return iconSilkDress;
                break;

            case "KeySlave":
                return iconKeySlave;
                break;

            case "KeyBarn":
                return iconKeyBarn;
                break;

            default:
                return null;
            break;
        }


        return null;
    }
}
