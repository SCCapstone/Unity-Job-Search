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
    public bool playVideo()
    {

        rawImage.texture = video.texture;
        video.Play();
        audio.Play();
        return true;
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
    public bool isDone()
    {
        if( (ulong)video.frame == video.frameCount)
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