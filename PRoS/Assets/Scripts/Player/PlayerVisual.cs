using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerVisual : MonoBehaviour
{
    public event EventHandler OnWalkingOnWoods;
    public event EventHandler OnWalkingOnStone;
    public event EventHandler OnWalkingOnSand;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    private Animator animator;

    private Vector3 lastPosition;
    private bool isMoving;
    private bool onWood;
    private bool onStone;
    private bool onSand;

    public Vector3 LastPosition { get { return lastPosition; } set { lastPosition = value; } }

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
        timeSinceLastEvent = Time.time; // Inisialisasi waktu sejak event terakhir diinvoke
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
                // Invoke the appropriate event based on the current ground type
                if (onWood)
                {
                    OnWalkingOnWoods?.Invoke(this, EventArgs.Empty);
                }
                else if (onStone)
                {
                    OnWalkingOnStone?.Invoke(this, EventArgs.Empty);
                }
                else if (onSand)
                {
                    OnWalkingOnSand?.Invoke(this, EventArgs.Empty);
                }

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

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        // Update the ground type based on the collision
        if (collision.CompareTag("Wood"))
        {

            onWood = true;
            onStone = false;
            onSand = false;
        }
        else if (collision.CompareTag("Sand"))
        {
            onSand = true;
            onStone = false;
            onWood = false;
        }
        else if (collision.CompareTag("Stone"))
        {
            onStone = true;
            onSand = false;
            onWood = false;
        }
    }

  
}
