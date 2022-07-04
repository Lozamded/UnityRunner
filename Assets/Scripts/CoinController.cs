using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("ToqueAlgo");
        if ( (other.tag).ToLower() == "player" )
        {
            FindObjectOfType<AudioManager>().PlaySfx("coin");
            LevelManager.CoinAmount += 1;
            gameObject.SetActive(false);
        }   
    }
}
