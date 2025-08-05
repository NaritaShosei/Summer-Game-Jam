using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] BGMSound, SFXSound;
    public AudioSource BGMSource, SFXSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(BGMSound, x => x._name == name);
        if (s != null)
        {
            BGMSource.clip = s._clip;
            BGMSource.volume = s._volume;
            BGMSource.loop = s._loop;
            BGMSource.mute = s._mute;
            BGMSource.Play();
        }
        else
        {
            Debug.Log("BGM not found");
        }

    }


    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSound, x => x._name == name);
        if (s != null)
        {
            SFXSource.clip = s._clip;
            SFXSource.volume = s._volume;
            SFXSource.loop = s._loop;
            SFXSource.mute = s._mute;
            SFXSource.PlayOneShot(s._clip);

        }
        else
        {
            Debug.Log("SFX not found");
        }

    }
}