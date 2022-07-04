using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject [] tilesObjects;
    public List<GameObject> activeTiles = new List<GameObject>();
    public float zSpawn = 0;
    public float tileLength = 30;
    public int tilesToItearte = 7;
    public float safespace = 35;
    public int previousIndex = 0;

    public Transform transformPlayer;



    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        for(int i = 1; i < tilesToItearte; i++ )
        {
            SpawnTile(Random.Range(1, tilesToItearte));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( transformPlayer.position.z - safespace > zSpawn - (tilesToItearte * tileLength) )
        {
            int index = Random.Range(0, tilesToItearte);
            while(index == previousIndex)
                index = Random.Range(0, tilesToItearte);

            DeleteFirstTile();
            SpawnTile(index);
        }
    }

    public void SpawnTile(int tileindex = 0)
    {
        Debug.Log(tileindex);
        int iterator = tileindex;
        GameObject tile = tilesObjects[iterator];
 
        while(tile.activeInHierarchy)
            if(tileindex < 20)
            {
                iterator += 1;
                tile = tilesObjects[iterator];
            }
            else
            {
                iterator = 0;
                tile = tilesObjects[iterator];
            }



        tile.transform.position = Vector3.forward * zSpawn;
        tile.transform.rotation = Quaternion.identity;
        tile.SetActive(true);

        activeTiles.Add(tile);
        zSpawn += tileLength;
        previousIndex = iterator;
    }

    public void DeleteFirstTile()
    {

        if (activeTiles[0].GetComponent<StarsSpawner>())
        {
            activeTiles[0].GetComponent<StarsSpawner>().Reset();
        }
        if(activeTiles[0].GetComponent<Tile1Controller>())
        {
            activeTiles[0].GetComponent<Tile1Controller>().Reset();
        }
        if(activeTiles[0].GetComponent<Tile2Controller>())
        {
            activeTiles[0].GetComponent<Tile2Controller>().Reset();
        }
        if(activeTiles[0].GetComponent<Tile3Controller>())
        {
            activeTiles[0].GetComponent<Tile3Controller>().Reset();
        }

        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
    }
}
