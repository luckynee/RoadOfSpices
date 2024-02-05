using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCameraManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject cameraToDisabled;
    [SerializeField] private GameObject cameraToEnabled;

    [Header("Refrences Ambience")]
    [SerializeField] private AudioSource ambienceToDisabled;
    [SerializeField] private AudioSource ambienceToEnabled;

    private TeleportController teleportController;

    private void Awake()
    {
        teleportController = GetComponent<TeleportController>();
    }

    private void Start()
    {
        teleportController.OnPlayerTeleport += TeleportController_OnPlayerTeleport;
    }

    private void TeleportController_OnPlayerTeleport()
    {
        ChangeCamera();
        ChangeAmbience();
    }

    private void ChangeCamera()
    {
        cameraToEnabled.SetActive(true);
        cameraToDisabled.SetActive(false);
    }

    private void ChangeAmbience()
    {
        ambienceToEnabled.Play();
        ambienceToDisabled.Stop();
    }
}
