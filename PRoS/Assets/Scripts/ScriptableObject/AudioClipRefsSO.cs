using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefsSO : ScriptableObject
{
    [Header("Walking")]
    [Space (10)]
    public AudioClip walkingInWoods;
    public AudioClip[] creekWalkingInWoods;
    public AudioClip walkingInSand;
    public AudioClip[] supportWalkingInSand;
    public AudioClip walkingInStone;

    [Header("Inventory")]
    [Space(10)]
    public AudioClip inventorySelectSound;
    public AudioClip inventoryAddItemSound;

    [Header("Dialogue")]
    [Space(10)]
    public AudioClip dialoguePopUpSound;
    public AudioClip questCompleteSound;
 
}