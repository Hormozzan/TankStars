using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPresenter : MonoBehaviour
{
    public GameObject Music;
    private bool MusicPlayed = true;
    private void Awake()
    {
        Music.GetComponent<AudioSource>().Play();
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            for (int i = 0; i<obj.Length-1; i++)
            {
                Destroy(obj[i]);
            }
        }
        DontDestroyOnLoad(Music);
    }
    public void MusicButtonClick()
    {
        
        if (MusicPlayed) Music.GetComponent<AudioSource>().Pause();
        else Music.GetComponent<AudioSource>().Play();
        MusicPlayed = !MusicPlayed;
    }
}
