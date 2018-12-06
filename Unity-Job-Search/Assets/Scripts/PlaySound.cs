using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioClip sound;
    public float Volume;
    AudioSource audio;
    public bool playedAlready = false;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!playedAlready)
        {
            audio.PlayOneShot(sound, Volume);
            playedAlready = true;
        }
	}
}
