using System;
using UnityEngine;
using UnityEngine.UI;


public class FirstDialog : MonoBehaviour
{
    [SerializeField] Text firstText;
    [SerializeField] GameObject firstBox;

    private bool isDialogActive = true;
    private GameController gameController; // Reference to GameController

    // Start is called before the first frame update
    void Start()
    {
        // Show the dialog at the beginning
        ShowDialog();

        // Find the GameController in the scene
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
        }
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        // Check for input in Update directly
        if (isDialogActive && Input.GetKeyDown(KeyCode.Z))
        {
            // If the dialog is currently active, hide it and start free roam
            HideDialog();

            // Check if GameController reference is available
            if (gameController != null)
            {
                gameController.setFreeroam();
            }
            else
            {
                Debug.LogError("GameController reference is null.");
            }
        }
    }

    void ShowDialog()
    {
        // Show the dialog and set the state accordingly
        firstBox.SetActive(true);
        isDialogActive = true;
    }

    void HideDialog()
    {
        // Hide the dialog and set the state accordingly
        firstBox.SetActive(false);
        isDialogActive = false;
    }
}
