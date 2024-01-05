using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform teleportDestinantionPoint;
    [SerializeField] private AILerp ai;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = player.GetComponent<AILerp>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position)>0.3f)
            {
                //ai.destination = teleportDestinantionPoint.position;
                ai.Teleport(teleportDestinantionPoint.position);
                if (ai.hasPath)
                {
                    
                }
               
                player.transform.position = teleportDestinantionPoint.transform.position;
                Debug.Log("Tele");
            }
            
        }
    }

}
