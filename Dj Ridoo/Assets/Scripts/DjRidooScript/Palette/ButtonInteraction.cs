using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class ButtonInteraction : MonoBehaviour
{
    public VideoPlayer displayVideoPlayer;
    public string videoFilePath;
    private bool displayVideoIsPaused = false;

    public void OnPlayClicked()
    {
        Debug.Log("Button1 is clicked");
        //1
        if (!displayVideoIsPaused)
        {
            //2
            displayVideoPlayer.playOnAwake = false;
            displayVideoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
            displayVideoPlayer.url = videoFilePath;
            displayVideoPlayer.frame = 0;
            displayVideoPlayer.isLooping = true;
        }

        //3
        displayVideoPlayer.Play();
        //4
        displayVideoIsPaused = false;
    }

    public void OnPauseClicked()
    {
        Debug.Log("Button2 is clicked");
        //1
        if (displayVideoIsPaused)
        {
            //2
            displayVideoPlayer.Play();
            displayVideoIsPaused = false;
        }
        else
        {
            //3
            displayVideoPlayer.Pause();
            displayVideoIsPaused = true;
        }
    }


    public void OnStopClicked()
    {
        Debug.Log("Button3 is clicked");
        //1
        displayVideoPlayer.Stop();
        //2
        displayVideoIsPaused = false;
    }


}
