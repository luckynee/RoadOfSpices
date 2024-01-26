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
    public int nameItem; // sudah ada name, nameItem harusnya gak di perlukan
    public int itemFunction; //game kita ga terlalu butuh function
}
