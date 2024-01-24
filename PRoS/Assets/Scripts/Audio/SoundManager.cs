using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    [SerializeField] private PlayerVisual playerVisual;

    private float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerVisual.OnWalking += PlayerVisual_OnWalking;
    }

    private void PlayerVisual_OnWalking(object sender, System.EventArgs e)
    {
        PlayWalkingOnWoodSound(Vector3.zero,volume);
        PlayCreekWalkingOnWoodSound(Vector3.zero, volume);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    public void PlayWalkingOnWoodSound(Vector3 position, float volume)
    {
        PlaySound(audioClipRefsSO.walkingInWoods, Vector3.zero, volume);
    }

    public void PlayCreekWalkingOnWoodSound(Vector3 position, float volume)
    {
        PlaySound(audioClipRefsSO.creekWalkingInWoods, Vector3.zero , volume);;
    }
}
