using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject dialogBox;
    [SerializeField] Text dialogText;

    [Header("Attributes")]
    [SerializeField] private int lettersPerSecond;

    private bool isDialogActive = false;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));

        // Set canMove to false when showing dialog
        AILerp aILerp = GameObject.FindObjectOfType<AILerp>();
        if (aILerp != null)
        {
            aILerp.canMove = false;
        }

    }

    public void HandleUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
                
                // Set canMove to true when dialog ends
                AILerp aILerp = GameObject.FindObjectOfType<AILerp>();
                if (aILerp != null)
                {
                    aILerp.canMove = true;
                }
            }
        }
    }
//muncul dialog per huruf
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            //kecepatan per huruf
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
