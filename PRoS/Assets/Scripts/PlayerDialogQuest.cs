using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogQuest : MonoBehaviour
{
    public static PlayerDialogQuest Instance;

    public LayerMask interactableLayer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            Interact();
            Debug.Log("SpamDisiniTagNPC");
        }
    }

    private void Interact()
    {
        
        var interactPos = transform.position;
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
}
