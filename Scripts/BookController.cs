using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour, Interactable
{
     public AudioClip bookSound;  // Drag and drop your audio file into this field in the Inspector
    private AudioSource audioSource;

    [SerializeField] Dialog dialog;

    void Start()
    {
        // Add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = bookSound;
    }


    public void Interact(){

        if (bookSound != null)
        {
            audioSource.PlayOneShot(bookSound);
        }

        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));

        

    }
}
