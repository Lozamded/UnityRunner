using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject [] tilesObjects;
    public List<GameObject> activeTiles = new List<GameObject>();
    public float zSpawn = 0;
    public float tileLenght = 30;
    public float tilesToItearte = 8;
    public float safespace = 35;

    public Transform transformPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        for(int i = 1; i < tilesToItearte; i++ )
        {
            SpawnTile(Random.Range(1, tilesObjects.Length));
            //activeTiles.app
        }


    }

    // Update is called once per frame
    void Update()
    {
        if ( transformPlayer.position.z - safespace > zSpawn - (tilesToItearte * tileLenght) )
        {
            SpawnTile(Random.Range(0, tilesObjects.Length));
            DeleteFirstTile();
        }
    }

    public void SpawnTile(int tileindex)
    {
        GameObject spnawnedtiled = Instantiate(tilesObjects[tileindex],transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;   
        activeTiles.Add(spnawnedtiled);
    }

    public void DeleteFirstTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
