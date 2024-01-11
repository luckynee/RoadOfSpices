using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCameraManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject cameraToDisabled;
    [SerializeField] private GameObject cameraToEnabled;

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
    }

    private void ChangeCamera()
    {
        cameraToEnabled.SetActive(true);
        cameraToDisabled.SetActive(false);
       
    }
}
