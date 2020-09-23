using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    protected float tileSize = 1;

    private int[,] levelMap =
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
        {1,2,2,2,2,1,8,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    protected int[,] RotationMap = {
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,3,3,3,0,0,3,3,3,3,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,1,1,2,0,1,1,1,1,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,1,1,3,0,0,3,0,0,1,1,1},
        {0,0,1,1,1,2,0,0,2,0,1,1,1,3},
        {0,0,0,0,0,0,0,0,2,0,0,0,0,0},
        {1,1,1,1,1,3,0,0,1,3,3,3,0,0},
        {0,0,0,0,0,0,0,0,0,1,1,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,1,1,0},
        {1,1,1,1,1,2,0,1,2,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

    void Start()
    {
        SpriteInstantiate();
        GenerateLevel(levelMap, 0f, 0f, 1, 1, 0);
        GenerateLevel(levelMap, -6.5f, -22f, -1, 1, 1);
        GenerateLevel(levelMap, -20.5f, -7.25f, 1, -1, 2);
        GenerateLevel(levelMap, -20.5f, -22f, -1, -1, 3);
    }

    private void SpriteInstantiate()
    {
        GameObject ghostN = (GameObject)Instantiate(Resources.Load("GhostNeon"), transform);
        ghostN.transform.position = new Vector3(12, -14, 10);
        GameObject ghostP = (GameObject)Instantiate(Resources.Load("GhostPink"), transform);
        ghostP.transform.position = new Vector3(13, -14, 10);
        GameObject ghostR = (GameObject)Instantiate(Resources.Load("GhostRed"), transform);
        ghostR.transform.position = new Vector3(12, -15, 10);
        GameObject ghostB = (GameObject)Instantiate(Resources.Load("GhostBlue"), transform);
        ghostB.transform.position = new Vector3(13, -15, 10);
    }

    private void GenerateLevel(int[,] map, float startcol, float startrow, int xquad, int yquad, int quadrant)
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                if (levelMap[row, col].Equals(0))
                {

                }
                if (levelMap[row, col].Equals(1))
                {
                    GameObject oCorner = (GameObject)Instantiate(Resources.Load("CornerOutside"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    oCorner.transform.position = new Vector3(posX, posY, 10);
                    RotateObject(oCorner, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(2))
                {
                    GameObject oWall = (GameObject)Instantiate(Resources.Load("WallOutside"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    oWall.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(oWall, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(3))
                {
                    GameObject iCorner = (GameObject)Instantiate(Resources.Load("CornerInside"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    iCorner.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(iCorner, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(4))
                {
                    GameObject iWall = (GameObject)Instantiate(Resources.Load("WallInside"), transform);
                    float posX = (col + startcol) * tileSize *yquad;
                    float posY = (row + startrow) * -tileSize *xquad;
                    iWall.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(iWall, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(5))
                {
                    GameObject nPellet = (GameObject)Instantiate(Resources.Load("PelletNormal"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    nPellet.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(nPellet, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(6))
                {
                    GameObject pPellet = (GameObject)Instantiate(Resources.Load("PelletPower"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    pPellet.transform.position = new Vector2(posX, posY);
                    RotateObject(pPellet, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(7))
                {
                    GameObject tJunction = (GameObject)Instantiate(Resources.Load("TJunction"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    tJunction.transform.position = new Vector3(posX, posY, 10f);
                    RotateObject(tJunction, row, col, quadrant, RotationMap);
                }
                if (levelMap[row, col].Equals(8))
                {
                    GameObject bCherry = (GameObject)Instantiate(Resources.Load("BonusCherry"), transform);
                    float posX = (col + startcol) * tileSize * yquad;
                    float posY = (row + startrow) * -tileSize * xquad;
                    bCherry.transform.position = new Vector3(posX, posY, 10f);
                }
            }
        }
        float GridH = levelMap.GetLength(0) * tileSize;
        float GridW = levelMap.GetLength(1) * tileSize;
        transform.position = new Vector2(-GridW / 2 + tileSize / 2, GridH / 2 - tileSize / 2);
    }

    private void RotateObject(GameObject obj, int row, int col, int quadrant, int [,] mapAdjustment)
    {
        if (quadrant.Equals(0))
        {
            if (mapAdjustment[row, col].Equals(0))
            {

            }
            else if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(0f, 0f, 90f);
            }
            else if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(0f, 0f, 180f);
            }
            else if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(0f, 0f, 270f);
            }
        }
        else if (quadrant.Equals(1))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(0f, 180f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(0f, 180f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(0f, 180f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(0f, 180f, 0f);
            }
        }
        else if (quadrant.Equals(2))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(180f, 0f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(180f, 0f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(180f, 0f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(180f, 0f, 0f);
            }
        }
        else if (quadrant.Equals(3))
        {
            if (mapAdjustment[row, col].Equals(1))
            {
                obj.transform.Rotate(180f, 180f, 90f);
            }
            if (mapAdjustment[row, col].Equals(2))
            {
                obj.transform.Rotate(180f, 180f, 180f);
            }
            if (mapAdjustment[row, col].Equals(3))
            {
                obj.transform.Rotate(0f, 0f, 270f);
            }
            if (mapAdjustment[row, col].Equals(0))
            {
                obj.transform.Rotate(180f, 180f, 0f);
            }
        }
    }
}