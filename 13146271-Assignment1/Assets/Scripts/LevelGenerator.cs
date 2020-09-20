using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    protected float tileSize = 1;
    protected int[,] mapAdjustment = {
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,1,1,3,0,0,1,1,1,3,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,1,1,2,0,1,1,1,1,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,1,1,3,0,0,3,0,0,1,1,1},
        {0,0,1,1,1,2,0,0,0,0,1,1,1,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,3,0,0,1,1,1,3,0,0},
        {0,0,0,0,0,0,0,0,0,1,1,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,1,1,0},
        {1,1,1,1,1,2,0,1,2,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

    protected int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int row = 0; row < levelMap.GetLength(1); row++)
        {
            for (int col = 0; col < levelMap.GetLength(0); col++)
            {
                if (levelMap[row,col].Equals(0))
                {
                    
                }
                if(levelMap[row,col].Equals(1))
                {
                    GameObject referenceOCorner = (GameObject)Instantiate(Resources.Load("Outside Corner"));
                    GameObject oCorner = (GameObject)Instantiate(referenceOCorner, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    oCorner.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row,col].Equals(2))
                {
                    GameObject referenceOWall = (GameObject)Instantiate(Resources.Load("Outside Wall"));
                    GameObject oWall = (GameObject)Instantiate(referenceOWall, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    oWall.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(3))
                {
                    GameObject referenceICorner = (GameObject)Instantiate(Resources.Load("Inside Corner"));
                    GameObject iCorner = (GameObject)Instantiate(referenceICorner, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    iCorner.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(4))
                {
                    GameObject referenceIWall = (GameObject)Instantiate(Resources.Load("Inside Corner"));
                    GameObject iWall = (GameObject)Instantiate(referenceIWall, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    iWall.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(5))
                {
                    GameObject referenceNPellet = (GameObject)Instantiate(Resources.Load("Normal Pellet"));
                    GameObject nPellet = (GameObject)Instantiate(referenceNPellet, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    nPellet.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(6))
                {
                    GameObject referencePPellet = (GameObject)Instantiate(Resources.Load("Power Pellet"));
                    GameObject pPellet = (GameObject)Instantiate(referencePPellet, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    pPellet.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(7))
                {
                    GameObject referenceTJunction = (GameObject)Instantiate(Resources.Load("T Junction"));
                    GameObject tJunction = (GameObject)Instantiate(referenceTJunction, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    tJunction.transform.position = new Vector2(posX, posY);
                }
            }
        }

        float GridH = levelMap.GetLength(0) * tileSize ;
        float GridW = levelMap.GetLength(1) * tileSize ;
        transform.position = new Vector2(-GridW / 2 + tileSize / 2, GridH / 2 - tileSize / 2);
    }

    private void RotateWall()
    {
        for(int col = 0; col < mapAdjustment.GetLength(0); col++)
        {
            for (int row = 0; row < mapAdjustment.GetLength(1); row++)
            {
                if (mapAdjustment[row, col] == 0)
                {

                }
            }
        }
    }
}
