using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1Controller : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] toGenerate;
    public List<GameObject> CreatedObjects = new List<GameObject>();

    void Start()
    {
        int cantOstacles = Random.Range(1, 4);
        int choosedPoint1 = Random.Range(0, 3);

        if (cantOstacles == 1)
        {
                for(int i = 0; i < 3; i++ )
                {
                    if (i == choosedPoint1)
                    {
                        int ChoosedObject = Random.Range(0,2);
                        GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]);
                    }
                }   

        }else if (cantOstacles == 2){

            for(int i = 0; i < 3; i++ )
            {
                if (i != choosedPoint1)
                {
                    int ChoosedObject = Random.Range(0,2);
                    GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]);
                }
            }   
        }else if (cantOstacles == 3){
            for(int i = 0; i < 3; i++ )
            {
                GameObject CreatedObject = Instantiate(toGenerate[0], spawnPoints[0]);
            }   
        }


    }

    public void Reset() 
    {
        foreach(GameObject createdObject in CreatedObjects)
        {
           Destroy(createdObject);
        }

        CreatedObjects = new List<GameObject>();
        Start();
    }
        

}
