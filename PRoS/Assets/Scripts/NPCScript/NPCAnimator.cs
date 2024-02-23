using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator; // --> pindahakan ke scriptVisual

    void Start()
    {
        animator = GetComponent<Animator>(); // pisah visual dan logic
    }

}
