using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour //Controlador de las estrellas
{
    public void OnTriggerEnter(Collider other) //Si colisiona con el player reproduce sonido y actualiza conteo de estrellas
    {
        //Debug.Log("ToqueAlgo");
        if ( (other.tag).ToLower() == "player" )
        {
            FindObjectOfType<AudioManager>().PlaySfx("coin");
            LevelManager.CoinAmount += 1;
            gameObject.SetActive(false); //Se desactiva
        }   
    }
}
