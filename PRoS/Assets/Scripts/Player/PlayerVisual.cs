using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerVisual : MonoBehaviour
{
    public event EventHandler OnWalking;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    private Animator animator;

    private Vector3 lastPosition;
    private bool isMoving;

    public Vector3 LastPosition { get { return lastPosition; } set {  lastPosition = value; } }

    [SerializeField] private float smoothing = 0.1f; // Nilai smoothing yang bisa diatur

    // Adjust this value to control the rate of event invocation
    [SerializeField] private float eventInvokeDelay = 0.5f;
    private float timeSinceLastEvent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        lastPosition = transform.position;
        timeSinceLastEvent = 0f;
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

            // Check if enough time has passed since the last event invocation
            if (Time.time - timeSinceLastEvent > eventInvokeDelay)
            {
                // Invoke the OnWalking event when the player is moving
                OnWalking?.Invoke(this, EventArgs.Empty);
                timeSinceLastEvent = Time.time; // Update the time of the last event invocation
            }
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);

            // If the player is not moving, set moveX and moveY directly to zero
            animator.SetFloat("moveX", 0f);
            animator.SetFloat("moveY", 0f);
        }

        lastPosition = currentPosition; // Menyimpan posisi terakhir untuk perbandingan di frame selanjutnya
    }
}
