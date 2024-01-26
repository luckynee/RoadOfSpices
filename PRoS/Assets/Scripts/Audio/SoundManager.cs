using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private AudioSource walkingAudio;
    [SerializeField] private AudioSource walkingBackSoundAudio;
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

    // Update is called once per frame
    void Update()
    {
        
    }

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
        walkingAudio.PlayOneShot(audioClipRefsSO.walkingInSand);
    }
}
