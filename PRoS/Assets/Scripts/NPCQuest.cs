using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ubah jadi scriptable object atau bisa di buat menjadi Interface
//penamaan scriptableObject kasi SO di belakang contohnya NPCQuestSO
public class NPCQuest : MonoBehaviour
{
    public bool isHaveQuest;
    public ItemData itemData; /* ubah jadi scriptable object item   misalnya --> public ItemData itemData; 
                                  Nanti tinggal di masukkan item apa yg di perlukan dalam quest di editor */
    public bool isOnQuestGiven;
    public Dialog dialogBelumNgasihQuest;
    public Dialog dialogLagiNgasihQuest;
    public Dialog dialogDiKasihItemQuest;
}
