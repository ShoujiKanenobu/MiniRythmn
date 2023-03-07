using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleFileBrowser;
using UnityEngine.Networking;

public class AudioManager : MonoBehaviour
{
    public AudioSource sampler;
    public AudioSource sound;

    public float delay;

    public AudioClip currentSound;

    //Loader
    private UnityWebRequest UWR;

    public void Awake()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Audio", ".wav", ".mp3"), new FileBrowser.Filter("Audio", ".wav", ".mp3"));
        FileBrowser.SetDefaultFilter(".mp3");

        

        LoadMusic();
    }

    public void StartMusic()
    {
        sampler.clip = currentSound;
        sound.clip = currentSound;

        sampler.Play();
        sound.PlayDelayed(delay);
    }

    public void StopMusic()
    {
        sampler.Stop();
        sound.Stop();
    }

    public void LoadMusic()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
        //Figure out how to load and set current sound
        //using SimpleFileBrowser
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Load Music", "Load");

        if(FileBrowser.Success)
        {
            /*for (int i = 0; i < FileBrowser.Result.Length; i++)
                Debug.Log(FileBrowser.Result[i]);*/ 

            UWR = UnityWebRequestMultimedia.GetAudioClip(FileBrowser.Result[0], AudioType.MPEG);
            yield return UWR.SendWebRequest();
            currentSound = DownloadHandlerAudioClip.GetContent(UWR);
        }
    }
}
