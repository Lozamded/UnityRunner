using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour //Creador(activador) de estrellas en los tiles
{

    public GameObject[] StarsGroups; //Grupos de estrellas en el tile


    void Start()
    {
        int choosedGroup = Random.Range(0, 3); //Numero aleatorio para escoger que grupo activar
        
        for(int i = 0; i < 3; i++ )
        {
            if (i != choosedGroup) //desactivo los gruopos de estrellas que no se utilizaran
            {
                StarsGroups[i].SetActive(false);
            }
        }
    }

    public void Reset() //Procedimiento que restaura las estrellas
    {
        foreach (GameObject starsGroup in StarsGroups) //activo todas las estrellas
        {
            starsGroup.SetActive(true);
        }
        Start(); //Se vuelven escoger las estrellas
    }

}
