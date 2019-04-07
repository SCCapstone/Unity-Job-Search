using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioClip sound;
    public float Volume;
    public AudioSource audio;
    public bool alreadyPlayed;

	// Use this for initialization
	void Start () {

        audio.clip = sound;

        alreadyPlayed = PlayerPrefs.GetInt(sound.name) == 1 ? true : false;
        Debug.Log("FIRST "+ (PlayerPrefs.GetInt(sound.name) == 1 ? true : false));
        
        if (alreadyPlayed == false)
        {
            audio.PlayOneShot(sound, Volume);
            alreadyPlayed = true;
            PlayerPrefs.SetInt(sound.name, 1);
            Debug.Log("TEST! " + (PlayerPrefs.GetInt(sound.name) == 1 ? true : false));
        }
        
        
    }
    
	
	// Update is called once per frame
	void Update () {
      
        
	}
}
