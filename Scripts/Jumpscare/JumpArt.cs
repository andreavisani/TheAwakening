using UnityEngine;
using System;

public class JumpArt : MonoBehaviour
{
    public JumpscareController jumpscareController; // Assign in the Unity Editor
    public event Action OnJumpscare;

    public void Interact()
    {
        performJumpscare();
    }

    private void performJumpscare()
    {
        OnJumpscare?.Invoke();

        if (jumpscareController != null)
        {
            jumpscareController.StartJumpscare();
        }
    }
}
