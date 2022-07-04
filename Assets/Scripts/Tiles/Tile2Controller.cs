using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2Controller : MonoBehaviour
{
    public GameObject[] springs;

    void Start()
    {
        int choosedSpring = Random.Range(0, 3);
        //Debug.Log(choosedSpring);

        
        for(int i = 0; i < 3; i++ )
        {

            if (i != choosedSpring)
            {
                springs[i].SetActive(false);
            }
        }
    }

}
