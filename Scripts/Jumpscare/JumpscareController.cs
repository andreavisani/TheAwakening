using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public AudioSource jumpscareAudio;
    public Camera jumpCamera;

    public Camera freeRoamCamera;
    public GameObject endGameButton;
    public Text endGameText;

    bool canEndGame = false;

    void Start()
    {
        // Disable the end game button initially
        endGameButton.SetActive(false);
    }

    void ShowEndGameButton()
    {
        canEndGame = true; // Enable the end game button
        endGameButton.SetActive(true);
        endGameText.text = "Press Z to end the game";
    }

    public void StartJumpscare()
    {
        jumpCamera.gameObject.SetActive(true);
        jumpCamera.enabled = true;
        freeRoamCamera.enabled = false;
        jumpCamera.tag = "MainCamera";

        freeRoamCamera.gameObject.SetActive(false); // Deactivate the game object of the previous main camera
        freeRoamCamera.tag = "Untagged"; // Remove the MainCamera tag from the previous main camera
        // Play jump scare audio
        jumpscareAudio.Play();

        // Show fullscreen image
        //fullscreenImage.enabled = true;

        // Add any other visual/audio effects or logic here

        // Set up a delayed callback for showing the end game button after 3 seconds
        Invoke("ShowEndGameButton", 3f);
    }

    public void HandleUpdate()
    {
        // Implement update logic for the jump scare
        // For example, you might want to check for user input to end the game
        if (canEndGame && Input.GetKeyDown(KeyCode.Z))
        {
            EndJumpscare();
        }
    }

    private void EndJumpscare()
{
    // Disable jump scare elements
    //jumpscareElements.SetActive(false);

    // Stop the jump scare audio
    jumpscareAudio.Stop();

    // Disable fullscreen image
    //fullscreenImage.enabled = false;

    // Disable the end game button
    endGameButton.SetActive(false);

    // Implement logic to end the game
    EndGame();
}

private void EndGame()
{
    // Add any additional cleanup or game-ending logic here
    //Debug.Log("Game Over! Closing application...");
    // You can replace the line below with the appropriate code to close the application
    Application.Quit();
    // Note: The application won't close when running in the Unity Editor.
    // To test this functionality, build and run the game outside the Unity Editor.
}


}
