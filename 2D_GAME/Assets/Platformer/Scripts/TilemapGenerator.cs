using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public int Amount_Blocks;
    void Start()
    {
        CreateArr();

    }

    void CreateArr()
    {
        int groundY = 0;
        int[] Width = new int[Amount_Blocks];
        int[] Height = new int[Amount_Blocks];
        for (int i = 0; i < Amount_Blocks; i++)
        {
            Width[i] = i;
            if ((i + 1) % 3 == 0 && i > 10)
            {
                if (groundY == 15)
                {
                    groundY += Random.Range(-1, 1);
                }
                else if (groundY == -15)
                {
                    groundY += Random.Range(0, 2);
                }
                else
                {
                    groundY += Random.Range(-1, 2);
                }
                Height[i] = groundY;
            }
            else Height[i] = groundY;
        }
        Generator(Width, Height);
        Debug.Log(Width.Length + "  " + Height.Length);
    }
    private void Generator(int[] W, int[] H)
    {

        for (int i = 0; i != Amount_Blocks - 1; i++)
        {
            int y = H[i];
            for (int j = 10; j !=0; j--)
            {
                y--;
                PlaceBlock(i, y);
            }
        }
    }
    private void PlaceBlock(int x, int y)
    {
        tilemap.SetTile(new Vector3Int(x, y, 0), tile);
    }
}
