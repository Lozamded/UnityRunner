using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile3Controller : MonoBehaviour
{
    public GameObject[] roads;
    public GameObject[] roadStars;

    void Start()
    {
        int numberOfRoads = Random.Range(1, 3);
        int choosedRoad = Random.Range(0, 3);
        //Debug.Log(choosedSpring);

        switch (numberOfRoads)
        {
            case 1:
                for(int i = 0; i < 3; i++ )
                {

                    if (i != choosedRoad)
                    {
                        roads[i].SetActive(false);
                        roadStars[i].SetActive(false);
                    }
                }
            break;
            case 2:
                for(int i = 0; i < 3; i++ )
                {
                    roadStars[i].SetActive(false);
                    if (i == choosedRoad)
                    {
                        roads[i].SetActive(false);
                    }
                }
            break;
        }
        
    }

    public void Reset()
    {
        foreach (GameObject road in roads)
        {
            road.SetActive(true);
        }

        foreach (GameObject starsGroup in roadStars)
        {
            starsGroup.SetActive(true);
        }

        Start();

    }
}
