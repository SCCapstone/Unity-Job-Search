using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewScript : MonoBehaviour {


    public GameObject InterviewCanvas;
    public GameObject q1Options;
    public GameObject q2Options;
    public GameObject q3Options;
    public GameObject q4Options;

    public GameObject ending;

    //public AudioSource q4Audio;
    //public AudioClip q4Clip;

    void Start () {
        //q1Options.setActive(false);
        


    }

    // Update is called once per frame
    int count = 0;
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && count == 0)
        {
            q2Options.active = true;
            //AudioSource q4Audio = q4Options.GetComponent<AudioSource>();
            // q4Audio.Play();
            count++;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && count == 1)
        {
            q3Options.active = true;
            //AudioSource q4Audio = q4Options.GetComponent<AudioSource>();
            // q4Audio.Play();
            count++;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && count == 2)
        {
            q4Options.active = true;
            //AudioSource q4Audio = q4Options.GetComponent<AudioSource>();
            // q4Audio.Play();
            count++;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && count == 3)
        {
            ending.active = true;
            q1Options.active = false;
            q2Options.active = false;
            q3Options.active = false;
            q4Options.active = false;
            //AudioSource q4Audio = q4Options.GetComponent<AudioSource>();
            // q4Audio.Play();
            //count++;

        }
        */

    }
}
