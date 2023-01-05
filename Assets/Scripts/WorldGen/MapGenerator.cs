using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;
    public Tilemap tilemap= new Tilemap();

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight,seed, noiseScale, octaves, persistance, lacunarity, offset);

        for(int y = 0; y < mapHeight; y++)
        {
            for(int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];

                Tile[] tileMap = new Tile[mapWidth * mapHeight];
                for(int i = 0; i < regions.Length; i++)
                {
                    if(currentHeight <= regions[i].height)
                    {
                        tileMap[y * mapWidth + x] = regions[i].tile;
                        break;
                    }
                }
            }
        }


        TextureGenerator.GenerateTiles(noiseMap, tilemap, regions);

    }

    [System.Serializable]
    public struct TerrainType {
        public string name;
        public float height;
        public Tile tile;

    }
}
