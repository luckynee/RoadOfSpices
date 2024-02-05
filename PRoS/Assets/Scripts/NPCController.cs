using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class NPCController : MonoBehaviour, Interactable
{
    
    public event EventHandler OnDialogStart;
    public event EventHandler OnQuestFinish;
    //Jgn lupa beri Header agar mempermudah game designer ketika mengatur di editor contohnya [Header("Refrences")] --> Refrences bisa di ganti sesuka hati tergantung pada kebutuhan
    [SerializeField] private NPCQuest nPCQuest;
    [Header("NPC Can Give Item?")]
    [SerializeField] private bool canGiveReward = true;
    [SerializeField] private ItemData rewardItemName;

    //jika npc langsung memberikan item tanpa quest
    [Header("NPC Give Direct Item")]
    [SerializeField] private bool givesDirectReward = false;
    [SerializeField] private ItemData directRewardItemName;

    //apakah npc memiliki animasi
    [Header("Animation NPC")]
    [SerializeField] private bool hasAnimation = false;

    [Header("NPC Dialog Non Quest/Quest is Complete")]
    [SerializeField] private Dialog dialog;

    private const string ISQUESTCOMPLETE = "isQuestComplete";

    private Animator animator; // --> pindahakan ke scriptVisual

    void Start()
    {
        animator = GetComponent<Animator>(); // pisah visual dan logic
    }

    public void Interact()
    {
        OnDialogStart?.Invoke(this, EventArgs.Empty);
        if (nPCQuest.isHaveQuest)
        {
            if (nPCQuest.isOnQuestGiven)
            {
                bool isPlayerHaveQuestItem = CheckPlayerInventoryForQuestItem();
                if (isPlayerHaveQuestItem)
                {
                    // kasih item -> kurangin inventory item nya
                    OnQuestFinish?.Invoke(this, EventArgs.Empty);
                    Inventory.Instance.RemoveItem(nPCQuest.itemData);

                    // dialog npc terima kasih
                    // ubah dialog NPC setelah menerima quest item
                    StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogDiKasihItemQuest));

                    //nonaktifkan quest pada NPC
                    nPCQuest.isHaveQuest = false;

                    // *optional = npc kasih item baru
                    if (canGiveReward)
                    {
                        //beri hadiah item ke player
                        Inventory.Instance.AddItem(rewardItemName);

                        //jika ada animasi 
                        if (hasAnimation && animator != null)
                        {
                            //aktifkan animasi
                            animator.SetBool(ISQUESTCOMPLETE, true); 
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
                PlayerQuest.instance.AddItemRequested(nPCQuest.itemData);

                //NPC memberikan quest atau dialog biasa
                if (givesDirectReward)
                {
                    //berikan hadiah langsung ke player
                    Inventory.Instance.AddItem(directRewardItemName);

                    if (hasAnimation && animator != null)
                    {
                        animator.SetBool(ISQUESTCOMPLETE, true);
                    }
                }
            }
        }
        else 
        {
            //Ngobrol biasa (tidak ada quest)
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }

    private bool CheckPlayerInventoryForQuestItem()
    {
        return Inventory.Instance.HasItem(nPCQuest.itemData);
    }

    /* ------NOTE-------
     * jika ada banyak NPC dengan isi fungsi yang sama bisa coba menggunakan Interface atau abstact Class
     */
}
