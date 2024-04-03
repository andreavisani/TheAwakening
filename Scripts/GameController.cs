using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Intro, Jumpscare }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] JumpscareController jumpscareController;
    [SerializeField] JumpArt jumpArt; // Reference to the JumpArt script

    [SerializeField] FirstDialog firstDialog;

    GameState state;

    // Start is called before the first frame update
    void Start()
    {
        // set game state to intro
        state = GameState.Intro;

        // start playing the intro dialog
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
            playerMovement.enabled = false; // Disable player movement
        };

        //switch from  dialog to free roaming when dialog ends
        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
                playerMovement.enabled = true; // Enable player movement
            }
        };

        jumpArt.OnJumpscare += TriggerJumpscare;
    }

    /** 
        change game mode to jumpscare
    */
    void TriggerJumpscare()
    {
        state = GameState.Jumpscare;
        playerMovement.enabled = false; // Disable player movement during jumpscare
        jumpscareController.StartJumpscare(); // Start jumpscare logic
    }

    public void setFreeroam()
    {
        state = GameState.FreeRoam;
    }

    // Update is called once per frame, change the game state based on events
    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerMovement.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Jumpscare)
        {
            jumpscareController.HandleUpdate();
        }
        else if (state == GameState.Intro)
        {
            firstDialog.HandleUpdate();
        }
    }
}





