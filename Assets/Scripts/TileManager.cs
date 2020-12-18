using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    public int offset = 4;
    public int tile_spawn_offset = 10;
    private List<GameObject> activeTiles = new List<GameObject>();
    private GameObject PreviousTile;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {   PlayerManager.numberOfSpecialCoins = 0;
        PreviousTile = new GameObject();
        for(int i=0; i<numberOfTiles;i++)
        {
            if(i==0)
                SpawnTile(2);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {   

        if (playerTransform.position.z - 40 >zSpawn - (numberOfTiles * tileLength))
        {   
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }


    }
    public void SpawnTile(int tileIndex)
    {   
        if (tilePrefabs[tileIndex].ToString() == PreviousTile.ToString()) SpawnTile(Random.Range(0, tilePrefabs.Length));
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward * (zSpawn + offset), transform.rotation);
        activeTiles.Add(go);
        if(PlayerManager.numberOfSpecialCoins >= 5)zSpawn += tileLength + tile_spawn_offset;
        else zSpawn += tileLength;

    }
    private void DeleteTile()
    {   
        PreviousTile = activeTiles[0];
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);   
    }

    
}
