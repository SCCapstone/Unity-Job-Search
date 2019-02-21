using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer video;
    public AudioSource audio;
    private bool isPaused = false;
    private bool firstRun = true;


    public IEnumerator prepareVideo()
    {
        video.Prepare();
        while (!video.isPrepared)
        {
            yield return new WaitForSeconds(1);
            break;
        }

    }
    public void playVideo()
    {

        rawImage.texture = video.texture;
        video.Play();
        audio.Play();
    }

    public bool isReady()
    {
        if (video.isPrepared)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PlayPause()
    {

        StartCoroutine(prepareVideo());
    }
}