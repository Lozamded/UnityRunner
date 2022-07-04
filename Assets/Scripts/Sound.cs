using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound //Tipo sonido
{
    public string soundName; //Nombre del sonido
    public AudioClip  clip; //clip

    public float volume = 1; //volumen
    public bool loop = false; //Se repite

    public AudioSource source; //Archivo de origen
}
