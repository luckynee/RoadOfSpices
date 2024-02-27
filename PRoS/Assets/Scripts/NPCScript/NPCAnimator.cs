using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Method untuk memulai animasi perpindahan posisi
    public void StartMoveAnimation()
    {
        animator.SetBool("IsMoving", true);
    }

    // Method untuk menghentikan animasi perpindahan posisi
    public void StopMoveAnimation()
    {
        animator.SetBool("IsMoving", false);
    }
}
