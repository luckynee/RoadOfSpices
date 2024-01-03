using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public bool IsQuestItem;    //tandai apakah ini item quest

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            Player.Instance.inventory.AddItem(ItemName);
            Destroy(gameObject);    
        }
    }
}