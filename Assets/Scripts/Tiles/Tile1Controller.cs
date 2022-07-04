using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1Controller : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] toGenerate;


    void Start()
    {
        int cantOstacles = Random.Range(1, 3);
        int choosedPoint1 = Random.Range(0, 3);

        switch (cantOstacles)
        {
            case 1:


                for(int i = 0; i < 3; i++ )
                {
                    if (i == choosedPoint1)
                    {
                        int ChoosedObject = Random.Range(0,2);
                        GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]);
                    }
                }   

            break;

            case 2:
            

                for(int i = 0; i < 3; i++ )
                {
                    if (i != choosedPoint1)
                    {
                        int ChoosedObject = Random.Range(0,2);
                        GameObject CreatedObject = Instantiate(toGenerate[ChoosedObject], spawnPoints[i]);
                    }
                }   


            break;

            case 3:

                for(int i = 0; i < 3; i++ )
                {
                    GameObject CreatedObject = Instantiate(toGenerate[0], spawnPoints[0]);
                }   

            break; 
            
        }
    }

}
