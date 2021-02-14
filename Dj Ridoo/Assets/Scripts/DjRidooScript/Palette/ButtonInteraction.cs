using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using System.IO;

public class ButtonInteraction : MonoBehaviour
{
    public VideoPlayer displayVideoPlayer;
    public string fileName;
    private bool displayVideoIsPaused = false;

    public void OnPlayClicked()
    {
        Debug.Log("Button1 is clicked");
        //1
        if (!displayVideoIsPaused)
        {
            //2
            //displayVideoPlayer.playOnAwake = false;
            displayVideoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
            Debug.Log("controllo piattaforma!");
            if (Application.platform == RuntimePlatform.Android)
            {
                Debug.Log(Application.platform.ToString());
                string rootPath = Application.persistentDataPath;
                Debug.Log(rootPath);
                displayVideoPlayer.url = Path.Combine(rootPath, fileName);
                //Debug.Log(Directory.GetFiles(rootPath, "*." + "mp4", SearchOption.AllDirectories));
                //string[] files = Directory.GetFiles(rootPath, "*." + "mp4", SearchOption.AllDirectories);
                //displayVideoPlayer.source = VideoSource.Url;
                //displayVideoPlayer.url = files[0];
                //displayVideoPlayer.sendFrameReadyEvents = true;
                //Debug.Log(displayVideoPlayer.url);
            }

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
