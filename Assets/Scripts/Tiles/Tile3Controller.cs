using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile3Controller : MonoBehaviour //Tile que genera caminos y vacios
{
    public GameObject[] roads; //Caminos
    public GameObject[] roadStars; //Estrellas del camino

    void Start()
    {
        int numberOfRoads = Random.Range(1, 3); //Numero aleatorio para elegir cantidad de caminos
        int choosedRoad = Random.Range(0, 3); //numero para escoger camino,varia segun cantidad de caminos
        //Debug.Log(choosedSpring);

        switch (numberOfRoads)
        {
            case 1: //Si es solo un camino el, el camino escogido no se desactiva
                for(int i = 0; i < 3; i++ )
                {

                    if (i != choosedRoad)
                    {
                        roads[i].SetActive(false);
                        roadStars[i].SetActive(false); //Si es un solo camino tiene estellas
                    }
                }
            break;
            
            case 2:// si son dos caminos, el número indica que camino desactivar
                for(int i = 0; i < 3; i++ )
                {
                    roadStars[i].SetActive(false); //Si son dos caminos no se activan estrella
                    if (i == choosedRoad)
                    {
                        roads[i].SetActive(false);
                    }
                }
            break;
        }
        
    }

    public void Reset() //Procedimiento que restaura el tile
    {
        foreach (GameObject road in roads) //activo los caminos
        {
            road.SetActive(true);
        }

        foreach (GameObject starsGroup in roadStars)//activo las estrellas
        {
            starsGroup.SetActive(true);
        }

        Start(); //Se vuelven a spawnear los caminos y estrellas
    }
}
