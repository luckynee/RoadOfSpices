using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ubah jadi scriptable object atau bisa di buat menjadi Interface
//penamaan scriptableObject kasi SO di belakang contohnya NPCQuestSO
public class NPCQuest : MonoBehaviour
{
    [Header("NPC Quest or NPC Non Quest")]
    public bool isHaveQuest;
    
    [Header("This Quest is Active")]
    public bool isOnQuestGiven;
    [Header("NPC Dialog Give Quest")]
    public Dialog dialogBelumNgasihQuest;
    [Header("NPC Request Item to Complete Quest")]
    public ItemData itemData; /* ubah jadi scriptable object item   misalnya --> public ItemData itemData; 
                                  Nanti tinggal di masukkan item apa yg di perlukan dalam quest di editor */
    [Header("NPC Dialog Remind the Quest")]
    public Dialog dialogLagiNgasihQuest;
    [Header("NPC Dialog Quest Complete + Give Item")]
    public Dialog dialogDiKasihItemQuest;
    
}
