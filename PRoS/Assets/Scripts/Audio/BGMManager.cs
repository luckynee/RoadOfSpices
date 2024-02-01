using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioSource;
    private float volume = .3f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    public void ChangeVolume()
    {
        audioSource.volume = volume;
    }
}
