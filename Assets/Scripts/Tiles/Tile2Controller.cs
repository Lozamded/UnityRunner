using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2Controller : MonoBehaviour
{
    public GameObject[] springs;

    void Start()
    {
        int choosedSpring = Random.Range(0, 3);

        for(int i = 0; i < 3; i++ )
        {
            if (i != choosedSpring)
            {
                springs[i].SetActive(false);
            }
        }
    }

    public void Reset()
    {
        foreach(GameObject spring in springs)
        {
            spring.SetActive(true);
            spring.GetComponent<SpringController>().active = false;
        }

        Start();
    }

}
