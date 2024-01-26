using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    //Jgn lupa beri Header agar mempermudah game designer ketika mengatur di editor contohnya [Header("Refrences")] --> Refrences bisa di ganti sesuka hati tergantung pada kebutuhan
    [SerializeField] private NPCQuest nPCQuest;
    [SerializeField] private bool canGiveReward = true;
    [SerializeField] private string rewardItemName;

    //jika npc langsung memberikan item tanpa quest
    [SerializeField] private bool givesDirectReward = false;
    [SerializeField] private string directRewardItemName;

    //apakah npc memiliki animasi
    [SerializeField] private bool hasAnimation = false;

    [SerializeField] private Dialog dialog;

    private bool hasInteracted = false; // --> jgn sampai ada script yang tidak digunakan, jika tidak di gunakan hapus saja 
    private Animator animator; // --> pindahakan ke scriptVisual

    void Start()
    {
        animator = GetComponent<Animator>(); // pisah visual dan logic
    }

    public void Interact()
    {
        if(nPCQuest.isHaveQuest) 
        {
            if(nPCQuest.isOnQuestGiven) 
            {
                bool isPlayerHaveQuestItem = CheckPlayerInventoryForQuestItem();

                if(isPlayerHaveQuestItem) 
                {
                    // kasih item -> kurangin inventory item nya
                    Player.Instance.inventory.SubtractItem(nPCQuest.itemQuestName);

                    // dialog npc terima kasih
                    // ubah dialog NPC setelah menerima quest item
                    StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogDiKasihItemQuest));
                    
                    //nonaktifkan quest pada NPC
                    nPCQuest.isHaveQuest = false;

                    // *optional = npc kasih item baru
                    if (canGiveReward)
                    {
                        //beri hadiah item ke player
                        Player.Instance.inventory.AddItem(rewardItemName);

                        //jika ada animasi 
                        if (hasAnimation && animator != null)
                        {
                            //aktifkan animasi
                            animator.SetBool("isQuestComplete", true); // ubah trigger menggunakan event agar bisa di akses script Visual NPC
                            /* jgn gunakan string , buat variable const baru --> private const string ISQUESTCOMPLETE = "isQuestComplete";
                            panggil pada animator contohnya animator.SetBool(ISQUESTCOMPLETE , true);
                            naming convention untuk const adalah Caps smua 
                            Setiap penggunaan string usahakan di buat const nya aja karena string itu case sensitive kalau ada salah penulisan akan error*/
                        }
                    }
                    

                    PlayerQuest.instance.activeQuestItem = "";
                }
                else 
                {
                    // Update dialog NPC setelah menyelesaikan quest
                    StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogLagiNgasihQuest));
                }
            }
            else 
            {
                // Update dialog NPC ketika memberikan quest
                StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogBelumNgasihQuest));
                nPCQuest.isOnQuestGiven = true;

                // minta barang
                PlayerQuest.instance.AddItemRequested(nPCQuest.itemQuestName);

                //NPC memberikan quest atau dialog biasa
                if (givesDirectReward)
                {
                    //berikan hadiah langsung ke player
                    Player.Instance.inventory.AddItem(directRewardItemName);

                    if (hasAnimation && animator != null)
                    {
                        animator.SetBool("isQuestComplete", true);//---> jgn menggunakan string
                    }
                }
            }
        }
        else 
        {
            {
                //Ngobrol biasa (tidak ada quest)
                StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
            }
            
        }
        
    }

    private bool CheckPlayerInventoryForQuestItem()
    {
        // Panggil method dari PlayerController.Instance
        //return PlayerController.Instance.CheckPlayerInventoryForQuestItem(nPCQuest.questItem);

        return Player.Instance.inventory.CheckItemHave(nPCQuest.itemQuestName);
    }

    /* ------NOTE-------
     * jika ada banyak NPC dengan isi fungsi yang sama bisa coba menggunakan Interface atau abstact Class
     */
}
