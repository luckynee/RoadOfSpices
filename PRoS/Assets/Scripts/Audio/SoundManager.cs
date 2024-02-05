using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private PlayerVisual playerVisual;

    [Header("Refrences SFX")]
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    [SerializeField] private AudioSource walkingAudio;
    [SerializeField] private AudioSource walkingBackSoundAudio; 
    [SerializeField] private AudioSource interactSoundAudio;
    [SerializeField] private AudioSource dialogueSoundAudio;

    [Header("Delay Antara Walk SFX dan Walk Support SFX")]
    [SerializeField] private float eventInvokeDelay = 0.2f;

    private float timeSinceLastEvent;
    private float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerVisual.OnWalkingOnWoods += PlayerVisual_OnWalkingOnWoods;
        playerVisual.OnWalkingOnSand += PlayerVisual_OnWalkingOnSand;
        playerVisual.OnWalkingOnStone += PlayerVisual_OnWalkingOnStone;
    }

    private void PlayerVisual_OnWalkingOnStone(object sender, System.EventArgs e)
    {
        PlayWalkingOnStoneSound();
    }

    private void PlayerVisual_OnWalkingOnSand(object sender, System.EventArgs e)
    {
        PlayWalkingOnSandSound();
        if (Time.time - timeSinceLastEvent > eventInvokeDelay)
        {
            PlayWalkingSupportOnSandSound();    
            timeSinceLastEvent = Time.time;
        }
    }

    private void PlayerVisual_OnWalkingOnWoods(object sender, System.EventArgs e)
    {
        
        PlayWalkingOnWoodsSound();
        if (Time.time - timeSinceLastEvent > eventInvokeDelay)
        {
            PlayCreekWalkingOnWoodsSound();
            timeSinceLastEvent = Time.time;
        }
    }

    #region WalkingSound
    private void PlayWalkingOnWoodsSound()
    {
        walkingAudio.PlayOneShot(audioClipRefsSO.walkingInWoods,volume);
    }

    private void PlayCreekWalkingOnWoodsSound()
    {
        walkingBackSoundAudio.PlayOneShot(audioClipRefsSO.creekWalkingInWoods[Random.Range(0, audioClipRefsSO.creekWalkingInWoods.Length)],volume);
    }

    private void PlayWalkingOnStoneSound()
    {
        walkingAudio.PlayOneShot(audioClipRefsSO.walkingInStone, volume);

    }

    private void PlayWalkingOnSandSound()
    {
        walkingAudio.PlayOneShot(audioClipRefsSO.walkingInSand, volume);
    }

    private void PlayWalkingSupportOnSandSound()
    {
        walkingBackSoundAudio.PlayOneShot(audioClipRefsSO.supportWalkingInSand[Random.Range(0, audioClipRefsSO.supportWalkingInSand.Length)], volume);
    }
    #endregion

    #region InventorySound
    private void PlayInventorySelectSound()
    {
        interactSoundAudio.PlayOneShot(audioClipRefsSO.inventorySelectSound,volume);
    }

    #endregion

    #region DialogueSound
    private void PlayOpenDialogueSound()
    {
        dialogueSoundAudio.PlayOneShot(audioClipRefsSO.dialoguePopUpSound,volume);
    }

    private void PlayOnQuestCompleteSound()
    {
        dialogueSoundAudio.PlayOneShot(audioClipRefsSO.questCompleteSound,volume);
    }

    #endregion

    public float GetVolume()
    {
        return volume;
    }
}
