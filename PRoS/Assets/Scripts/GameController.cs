using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerDialogQuest playerDialogQuest;
    [SerializeField] private Collider2D playerCollider;

    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () => 
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            

        } else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();

        } else if (state == GameState.Battle)
        {

        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += OnShowDialog;
        DialogManager.Instance.OnHideDialog += OnHideDialog;
    }

    private void OnDestroy()
    {
        DialogManager.Instance.OnShowDialog -= OnShowDialog;
        DialogManager.Instance.OnHideDialog -= OnHideDialog;
    }

    private void OnShowDialog()
    {
        state = GameState.Dialog;
    }

    private void OnHideDialog()
    {
        if (state == GameState.Dialog)
            state = GameState.FreeRoam;
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {

        }
    }
}*/