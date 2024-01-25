using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    public new string name;
    public Sprite visual;
    [TextArea]
    public string description;
    public int nameItem;
    public int itemFunction;
}
