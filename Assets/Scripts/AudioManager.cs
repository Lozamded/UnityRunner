using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] songs;
    public Sound[] sfxs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound sound in songs)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sfx in sfxs)
        {
            sfx.source = gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.clip;
            sfx.source.loop = sfx.loop;
        }

        PlaySound("song","Main");
    }

    public void PlaySound(string type,string name)
    {
        Sound[] choosedArray = songs;

        switch (type)
        {
            case "song":
                choosedArray = songs;
            break;
            case "sfx":
                choosedArray = sfxs;
            break;

        }

        foreach (Sound sound in choosedArray)
        {
            if( sound.soundName == name )
            {
                sound.source.Play();
            }
        }
    }

    public void PlaySong(string name)
    {
        foreach (Sound song in songs)
        {
            if( song.soundName == name )
            {
                song.source.Play();
            }
        }
    }

    public void PlaySfx(string name)
    {
        foreach (Sound sfx in sfxs)
        {
            if( sfx.soundName == name )
            {
                sfx.source.Play();
            }
        }
    }

    public void PauseSong(string name)
    {
        foreach (Sound song in songs)
        {
            if( song.soundName == name )
            {
                song.source.Pause();
            }
        }
    }

    public void ResumeSong(string name)
    {
        foreach (Sound song in songs)
        {
            if( song.soundName == name )
            {
                song.source.UnPause();
            }
        }
    }


    public void StopSong(string name)
    {
        foreach (Sound song in songs)
        {
            if( song.soundName == name )
            {
                song.source.Stop();
            }
        }
    }



}
