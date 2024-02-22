using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //npc memiliki quest lagi
    [SerializeField] private bool haveQuest;

    //apakah npc memiliki animasi
    [Header("Animation NPC")]
    [SerializeField] private bool hasAnimation = false;

    [Header("NPC Dialog Non Quest/Quest is Complete")]
    [SerializeField] private Dialog dialog;

    private NPCAnimator nPCAnimator;

    private const string ISQUESTCOMPLETE = "isQuestComplete";

    private void Start()
    {
        nPCAnimator = GetComponent<NPCAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interact();
            Debug.Log("SpamDisiniTagPlayer");
        }
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
                    
                    //Fungsi Quest Kedua Mulai dari sini
                    if (nPCQuest.isHaveQuest && nPCQuest.isOnQuestGiven)
                    {
                        // Pengecekan quest kedua setelah menyelesaikan quest pertama
                        if (nPCQuest.isHaveSecondQuest)
                        {
                            // Lakukan aksi atau tampilkan dialog untuk quest kedua
                            // Contoh:
                            StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogSecondQuest));
                        }
                        else
                        {
                            // Lakukan aksi atau tampilkan dialog untuk quest pertama
                            // Contoh:
                            StartCoroutine(DialogManager.Instance.ShowDialog(nPCQuest.dialogLagiNgasihQuest));
                        }
                    }

                    //nonaktifkan quest pada NPC
                    nPCQuest.isHaveQuest = false;

                    // *optional = npc kasih item baru
                    if (canGiveReward)
                    {
                        //beri hadiah item ke player
                        Inventory.Instance.AddItem(rewardItemName);

                        //jika ada animasi 
                        if (hasAnimation && nPCAnimator != null)
                        {
                            //aktifkan animasi
                            nPCAnimator.StartMoveAnimation();
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

                    if (hasAnimation && nPCAnimator != null)
                    {
                        //aktifkan animasi
                        nPCAnimator.StartMoveAnimation();
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
