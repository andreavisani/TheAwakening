using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
   [SerializeField] GameObject dialogBox;
   [SerializeField] Text dialogText;
   [SerializeField] int lettersPerSecond;

   public event Action OnShowDialog;
   public event Action OnCloseDialog;

   private bool isTyping;
   int currentLine = 0;

   Dialog dialog;

   public static DialogManager Instance { get; private set; }

   private void Awake()
   {
    Instance = this;
   }

   public IEnumerator ShowDialog(Dialog dialog)
   {

    yield return new WaitForEndOfFrame();
    OnShowDialog?.Invoke();

    this.dialog = dialog;
    dialogBox.SetActive(true);
    StartCoroutine(TypeDialog(dialog.Lines[0]));
    
   }

public void HandleUpdate()
{
    if (Input.GetKeyDown(KeyCode.Z))
    {
        if (isTyping)
        {
            // If typing, complete the typing instantly
            StopAllCoroutines();
            dialogText.text = dialog.Lines[currentLine];
            isTyping = false;
        }
        else
        {
            // If not typing, proceed to the next line
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                // If there are no more lines, close the dialog
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }
}


public IEnumerator TypeDialog(string line)
{
    isTyping = true;
    dialogText.text = ""; // Clear the text before typing the new line

    for (int i = 0; i < line.Length; i++)
    {
        dialogText.text += line[i];
        //Debug.Log("Added character: " + line[i] + ", ASCII: " + (int)line[i]);
        yield return new WaitForSeconds(1f / lettersPerSecond);
    }

    isTyping = false;
}




}
