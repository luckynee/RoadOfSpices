using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;
    private Animator animator;

    public bool isTeleport;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public static PlayerController Instance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Instance = this;
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    

    private void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && isTeleport == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        if(isTeleport == false) 
        {
            transform.position = targetPos;   
        }

        isTeleport = false;

        isMoving = false;
    }

    Vector3 targetPosDebug;
    //gabisa jalan nabrak layer solid & interactable
    private bool IsWalkable(Vector3 targetPos)
    {
        targetPosDebug = targetPos;
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }

        return true;

    }

    public void IsTeleporting() 
    {
    isTeleport = true;

    }

    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosDebug, 0.2f);
    }

    // Metode ini digunakan untuk memeriksa apakah pemain memiliki item quest di inventory
    //public bool CheckPlayerInventoryForQuestItem(QuestItem questItem)
    //{
        // Gantilah baris di bawah ini dengan logika yang sesuai dengan game Anda
        // Contoh: return PlayerInventory.HasItem(nPCQuest.questItem);
        // Implementasikan logika pemeriksaan inventory di sini
        // Misalnya, return PlayerInventory.HasItem(questItem);
        //return true; // Gantilah ini sesuai dengan kebutuhan
    //}
}