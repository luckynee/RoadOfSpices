using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    private Animator animator;

    private Vector3 lastPosition;
    private bool isMoving;

    [SerializeField] private float smoothing = 0.1f; // Nilai smoothing yang bisa diatur

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Menghitung perbedaan posisi antara frame terakhir dan sekarang
        Vector3 movementDirection = currentPosition - lastPosition;

        if (movementDirection.magnitude > 0.01f) // Pastikan ada pergerakan yang cukup signifikan
        {
            isMoving = true;
            animator.SetBool("isMoving", isMoving);

            float smoothX = Mathf.Lerp(animator.GetFloat("moveX"), movementDirection.x, smoothing);
            float smoothY = Mathf.Lerp(animator.GetFloat("moveY"), movementDirection.y, smoothing);

            animator.SetFloat("moveX", smoothX);
            animator.SetFloat("moveY", smoothY);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

        lastPosition = currentPosition; // Menyimpan posisi terakhir untuk perbandingan di frame selanjutnya
    }
}
