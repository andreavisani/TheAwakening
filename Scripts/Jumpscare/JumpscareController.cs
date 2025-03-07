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

        jumpscareAudio.Play();

        Invoke("ShowEndGameButton", 3f);
    }

    public void HandleUpdate()
    {
        if (canEndGame && Input.GetKeyDown(KeyCode.Z))
        {
            EndJumpscare();
        }
    }

    private void EndJumpscare()
{

    jumpscareAudio.Stop();

    endGameButton.SetActive(false);


    EndGame();
}

private void EndGame()
{
    Application.Quit();
}


}
