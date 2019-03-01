using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class notificationScript : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        
    }

    void playSound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
