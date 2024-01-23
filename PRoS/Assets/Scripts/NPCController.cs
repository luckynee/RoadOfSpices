using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] private NPCQuest nPCQuest;
    [SerializeField] private bool canGiveReward = true;
    [SerializeField] private string rewardItemName;

    //jika npc langsung memberikan item tanpa quest
    [SerializeField] private bool givesDirectReward = false;
    [SerializeField] private string directRewardItemName;

    //apakah npc memiliki animasi
    [SerializeField] private bool hasAnimation = false;

    [SerializeField] private Dialog dialog;

    private bool hasInteracted = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
                            animator.SetBool("isQuestComplete", true);
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
                        animator.SetBool("isQuestComplete", true);
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
}
