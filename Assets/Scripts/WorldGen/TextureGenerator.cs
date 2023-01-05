using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TextureGenerator : MapGenerator
{

    public static void GenerateTiles(float[,] heightMap, Tilemap tilemap, TerrainType[] regions) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                float heightValue = heightMap[x,y];
                for(int i = 0; i < regions.Length; i++) {
                    if(heightValue < regions[i].height)  {
                        tilemap.SetTile(new Vector3Int(x,y,0), regions[i].tile);
                    }
                }
            }
        }
    }
}
