using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMap : MonoBehaviour
{
    public Transform player;
    public Transform posisiTujuan;

    public GameObject cameraToActive;
    public GameObject cameraToDeavtive;


    //DETEKSI TRIGGER DARI PLAYER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPindahMap();
    }

    public void PlayerPindahMap()
    {
        //PINDAHIN PLAYER
        player.position = posisiTujuan.position;
        player.GetComponent<PlayerController>().IsTeleporting();

        //NYALAIN KAMERA BERIKUTNYA
        cameraToActive.SetActive(true);

        //MATIIN KAMERA SEBELUMNYA
        cameraToDeavtive.SetActive(false);
    }

    //PLAYER PERLU DI PINDAH MAP
}