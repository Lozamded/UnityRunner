using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2Controller : MonoBehaviour //Tile que genera resortes 
{
    public GameObject[] springs; //Resortes posibles

    void Start()
    {
        int choosedSpring = Random.Range(0, 3); //número aleatorio para escoger restorte

        for(int i = 0; i < 3; i++ )
        {
            if (i != choosedSpring) //Desactivo los resortes no escofigos
            {
                springs[i].SetActive(false);
            }
        }
    }

    public void Reset() //Procedimiento que restaura el tile
    {
        foreach(GameObject spring in springs) //Se vuelven activar los resortes
        {
            spring.SetActive(true);
            spring.GetComponent<SpringController>().active = false; //se asigna como no utilizado por el player
        }

        Start(); //Se vuelve a escoger resorte
    }

}
