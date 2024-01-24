using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite visual;

    public int nameItem;
    public int itemFunction;
}
