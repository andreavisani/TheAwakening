using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioS;
    void Start(){
        audioS = GetComponent<AudioSource>();        
    }
    public void PlayGame(){

        audioS.PlayOneShot(audioClip);
        
        SceneManager.LoadScene("GamePlay");
    }

    public void EndGame(){
        audioS.PlayOneShot(audioClip);
        Debug.Log("Exiting....");
        Application.Quit();
    }


}


