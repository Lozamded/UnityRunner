using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1Controller : MonoBehaviour //Tile que genera obstaculos en una linea
{
    public Transform[] spawnPoints; //puntos para generar obstaculos
    public GameObject[] toGenerate; //Obstaculos que puedo generar
    public List<GameObject> CreatedObjects = new List<GameObject>(); //Lista de objetos creados

    void Start()
    {
        int cantOstacles = Random.Range(1, 4); //numero aleatorio para saber cuantos obstaculos creare
        int choosedPoint1 = Random.Range(0, 3); //punto de spawn escogido, varia su funcion segun la cantidad de objetos

       switch (cantOstacles) {
        case 1: //Si solo se generara un obstaculo el punto escogido lo instanciara
             for(int i = 0; i < 3; i++ )
                {
                    if (i == choosedPoint1)
                    {
                        int ChoosedObject = Random.Range(0,2); //numero aleatorio para elegir el obstaculo
                        GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]); //crear el objeto
                        CreatedObjects.Add(CreatedObject); //se añade al a lista
                    }
                }   
        break;

        case 2://Si se generaran dos obstaculos el punto escogido indica donde no se instanciara
          for(int i = 0; i < 3; i++ )
            {
                if (i != choosedPoint1)
                {
                    int ChoosedObject = Random.Range(0,2);
                    GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]); //crea un objeto
                    CreatedObjects.Add(CreatedObject);//se añade al a lista
                }
            }   
        break;
        
        case 3://Si se generan 3 obstaculos no necesito el indicador de posicion
          for(int i = 0; i < 3; i++ )
            {
                GameObject CreatedObject = Instantiate(toGenerate[0], spawnPoints[i]); //creo un objeto, solo puede ser del tipo saltable
                CreatedObjects.Add(CreatedObject);//se añade al a lista
            }   
        break;

       }

    }

    public void Reset() //Procedimiento que restaura el tile
    {
        foreach(GameObject createdObject in CreatedObjects) //Destruyo los objetos de la lista
        {
           Destroy(createdObject);
        }

        CreatedObjects = new List<GameObject>(); //se vacia
        Start(); //Se vuelven a spawnear los obstaculos
    }
        

}
