using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour //Administrador de audios
{
    public Sound[] songs; //Lista de canciones
    public Sound[] sfxs; //Lista de sonidos

    void Start()//Añado el comonente de origen a todos los audios
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

        PlaySound("song","Main"); //reproducir canción del nivel
    }

    public void PlaySound(string type,string name) //Reproductor universal
    {
        Sound[] choosedArray = songs;

        switch (type) //Verificar si es cancion o efecto
        {
            case "song":
                choosedArray = songs;
            break;
            case "sfx":
                choosedArray = sfxs;
            break;

        }

        foreach (Sound sound in choosedArray) //Buscar y reproducir sonido
        {
            if( sound.soundName == name )
            {
                sound.source.Play();
            }
        }
    }

    public void PlaySong(string name) //reproducir canción
    {
        foreach (Sound song in songs) //Buscar y reproducir sonido
        {
            if( song.soundName == name )
            {
                song.source.Play();
            }
        }
    }

    public void PlaySfx(string name) //reproducir efecto
    {
        foreach (Sound sfx in sfxs) //Buscar y reproducir sonido
        {
            if( sfx.soundName == name )
            {
                sfx.source.Play();
            }
        }
    }

    public void PauseSong(string name) //Pausar canción
    {
        foreach (Sound song in songs) //Buscar y pausar sonido
        {
            if( song.soundName == name )
            {
                song.source.Pause();
            }
        }
    }

    public void ResumeSong(string name) //Reanudar canción
    {
        foreach (Sound song in songs) //Buscar y reaunudar sonido
        {
            if( song.soundName == name )
            {
                song.source.UnPause();
            }
        }
    }


    public void StopSong(string name) //Detener canción
    {
        foreach (Sound song in songs) //Buscar y detener sonido
        {
            if( song.soundName == name )
            {
                song.source.Stop();
            }
        }
    }


}
