using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioClip sound;
    public float Volume;
    AudioSource audio;
    public bool playedAlready;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        playedAlready = false;
        playedAlready = PlayerPrefs.GetInt(sound.name) == 1 ? true : false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!playedAlready)
        {
            audio.PlayOneShot(sound, Volume);
            playedAlready = true;
            PlayerPrefs.SetInt(sound.name, playedAlready ? 1 : 0);
        }
        
	}
}
