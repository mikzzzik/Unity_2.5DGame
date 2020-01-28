using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTerrainGenerator : MonoBehaviour
{
    public GameObject Block_Upper;
    public GameObject Block_Under;
    public GameObject Block_Right_Upper;
    public GameObject Block_Left_Upper;
    public GameObject Block_Under_Right;
    public GameObject Block_Under_Left;
    private GameObject Block;
    public Transform Zero;
    public int Amount_Blocks;
    void Start()
    {
        CreateArr();
        //Generator();
            
    }
    private void CreateArr()
    {
        int groundY = 25;
        int[] Width = new int[Amount_Blocks];
        int[] Height = new int[Amount_Blocks];
        
        for (int i = 0; i < Amount_Blocks; i++)
        {
            Width[i] = i;          
            if ((i + 1) % 3 == 0 && i > 10) 
            {
                if (groundY == 35)
                {
                    groundY += Random.Range(-1, 1);
                }
                else if (groundY == 15)
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
    private void Generator(int[] W,int[] H)
    {

        for (int i = 0; i < Amount_Blocks-1; i++)
        {
        
            if (i != 0)
            {
                if (H[i] > H[i - 1])    
                {
                    Block = Block_Left_Upper;
                }
                else if (H[i] > H[i + 1])
                {
                    Debug.Log(H[i]);
                    Debug.Log(H[i + 1]);
                    Block = Block_Right_Upper;
                }
                else Block = Block_Upper;
                PlaceBlock(W[i], H[i], Block);
                for (int y = H[i]-1;y != H[i]-9; y--)
                {
                    if (H[i] > H[i + 1] && y == H[i]-1)
                    {
                        Block = Block_Under_Right;
                    }
                    else if (H[i] > H[i - 1] && y == H[i] - 1)
                    {
                        Block = Block_Under_Left;
                    }
                    else
                    {
                        Block = Block_Under;
                    }
                    PlaceBlock(W[i], y, Block);
                }

            } else Block = Block_Upper;
            
        }
    }
    private void PlaceBlock(int x,int y, GameObject Block)
    {
        var cell = Instantiate(Block, Zero);
        cell.transform.localPosition = new Vector3(x, y, 0);
        cell.name = ("Block " + x + " " + y);
    }
}
