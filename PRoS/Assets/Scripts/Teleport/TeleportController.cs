using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform teleportDestinantionPoint;
    [SerializeField] private AILerp ai;
    [SerializeField] private Seeker seeker;
    [SerializeField] private Camera cameraTujuan;
    [SerializeField] private Camera cameraAwal;

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
                seeker.StartPath(transform.position, teleportDestinantionPoint.position, OnPathComplete);
                cameraTujuan.enabled = true;
                cameraAwal.enabled = false;

            }
            
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            // Set path baru ke AILerp
            ai.SetPath(p);
        }
        else
        {
            Debug.LogError("Terjadi kesalahan saat menghitung path baru: " + p.errorLog);
        }
    }

}
