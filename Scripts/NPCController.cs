using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controller for the npcs dialogs*/
public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
   public void Interact()
   {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
   }
}
