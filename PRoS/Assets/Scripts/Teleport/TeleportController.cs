using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public event Action OnPlayerTeleport;

    [Header("Refrences")]
    [SerializeField] private Transform teleportDestinantionPoint;
    private AILerp ai;
    private Seeker seeker;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = player.GetComponent<AILerp>();
        seeker = player.GetComponent<Seeker>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if(Vector2.Distance(player.transform.position, transform.position)>0.3f)
            {
                ai.Teleport(teleportDestinantionPoint.position, true);

                // Set path baru dari posisi AI ke teleportDestinationPoint setelah teleportasi
                if (!ai.hasPath)
                {
                    seeker.StartPath(teleportDestinantionPoint.position, teleportDestinantionPoint.position, OnPathComplete) ;
                }
                OnPlayerTeleport?.Invoke();
                
            }
            
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            // Tidak perlu melakukan apa-apa di sini karena AILerp akan otomatis mengikuti path yang dihitung oleh Seeker
           
        }
        else
        {
            Debug.LogError("Terjadi kesalahan saat menghitung path baru: " + p.errorLog);
        }
    }
}
