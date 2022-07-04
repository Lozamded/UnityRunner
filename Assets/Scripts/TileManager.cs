using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject [] tilesObjects; //Lista con todos los tiles
    public List<GameObject> activeTiles = new List<GameObject>(); //tiles que podria estar recorriendo el personaje
    public float zSpawn = 0; //posición en z para generar tiles
    public float tileLength = 30; //Largo de los tiles
    public int tilesToItearte = 7; //Cuandos tiles tendre en simultaneo
    public float safespace = 35; //espacio para eliminar tiles
    public int previousIndex = -1; //tile anterior al que active

    public Transform transformPlayer; //Ubicación del player



    void Start()
    {
        SpawnTile(0); //Generar primer tile
        for(int i = 1; i < tilesToItearte; i++ ) //Generar los 7 primeros
        {
            SpawnTile(Random.Range(1, tilesToItearte));
        }
    }

    void Update()
    {
        if ( transformPlayer.position.z - safespace > zSpawn - (tilesToItearte * tileLength) ) //si avanzo el player lo suficiente genero tiles
        {
            int index = Random.Range(1, tilesToItearte); //numero aleatorio para elegir un tile
            while(index == previousIndex) //Si es igual al anterior lo vuelbvo a asignar
                index = Random.Range(1, tilesToItearte);

            DeleteFirstTile(); //borro el que mas atras dejo el player
            SpawnTile(index); //Genero el tile al azar
        }
    }

    public void SpawnTile(int tileindex = 0) //generar un tile
    {
        Debug.Log(tileindex);
        int iterator = tileindex;
        GameObject tile = tilesObjects[iterator]; //tomo del arreglo un tile
 
        while(tile.activeInHierarchy) //Si el tile ya esta en uso debo escoger otro
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


        //una vez escogido uno no en uso, se posiciona y se activa
        tile.transform.position = Vector3.forward * zSpawn;
        tile.transform.rotation = Quaternion.identity;
        tile.SetActive(true); 

        activeTiles.Add(tile); //lo añado al a lista de activos
        zSpawn += tileLength; //Donde se posicionara el proximo tile
        previousIndex = iterator; //asigno el indice del tile como el anterior
    }

    public void DeleteFirstTile() //Borro el tile mas lejano recorrido por el player
    {

        //Reviso si tiene los componentes que generan obstaculos y monedas para resetarla
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

        activeTiles[0].SetActive(false); //lo desactivo
        activeTiles.RemoveAt(0); //lo quito de la lista
    }
}
