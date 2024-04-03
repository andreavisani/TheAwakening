using UnityEngine;
using System;

public class JumpArt : MonoBehaviour
{
    public JumpscareController jumpscareController; // Assign in the Unity Editor
    public event Action OnJumpscare;

    public void Interact()
    {
        // Implement the interaction logic for JumpArt
        // ...

        // Call performJumpscare when interacted
        performJumpscare();
    }

    private void performJumpscare()
    {
        // Trigger the jumpscare event
        OnJumpscare?.Invoke();

        // Access the JumpscareController
        if (jumpscareController != null)
        {
            jumpscareController.StartJumpscare();
        }
    }
}