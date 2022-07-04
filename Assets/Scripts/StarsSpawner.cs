using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{

    public GameObject[] StarsGroups;


    void Start()
    {
        int choosedGroup = Random.Range(0, 3);
        //Debug.Log(choosedGroup);
        
        for(int i = 0; i < 3; i++ )
        {

            if (i != choosedGroup)
            {
                StarsGroups[i].SetActive(false);
            }
        }
    }

    public void Reset()
    {
        foreach (GameObject starsGroup in StarsGroups)
        {
            starsGroup.SetActive(true);
        }
        Start();
    }

}
