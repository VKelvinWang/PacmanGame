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

    protected int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,9,5,5,5,5,5,5,5,5,5,5,5,4},
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
        {0,0,0,0,0,0,5,0,0,0,4,0,0,11},
    };

    void Awake()
    {
        GenerateLevel(levelMap, 0f, 0f, 1, 1, 1);
        GenerateLevel(levelMap, 10f, 0f, -1, 1, 2);
        //GenerateLevel(levelMap, 0, 0, 1, -1, 3);
        //GenerateLevel(levelMap, 0, 0, -1, -1, 4);
    }

    private void GenerateLevel(int[,] map, float startcol, float startrow, int xvar, int yvar, int quad)
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
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    oCorner.transform.position = new Vector2(posX, posY);
                    RotateObject(oCorner, row, col, quad);
                }
                if (levelMap[row, col].Equals(2))
                {
                    GameObject oWall = (GameObject)Instantiate(Resources.Load("WallOutside"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    oWall.transform.position = new Vector2(posX, posY);
                    RotateObject(oWall, row, col, quad);
                }
                if (levelMap[row, col].Equals(3))
                {
                    GameObject iCorner = (GameObject)Instantiate(Resources.Load("CornerInside"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    iCorner.transform.position = new Vector2(posX, posY);
                    RotateObject(iCorner, row, col, quad);
                }
                if (levelMap[row, col].Equals(4))
                {
                    GameObject iWall = (GameObject)Instantiate(Resources.Load("WallInside"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    iWall.transform.position = new Vector2(posX, posY);
                    RotateObject(iWall, row, col, quad);
                }
                if (levelMap[row, col].Equals(5))
                {
                    GameObject nPellet = (GameObject)Instantiate(Resources.Load("PelletNormal"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    nPellet.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(6))
                {
                    GameObject pPellet = (GameObject)Instantiate(Resources.Load("PelletPower"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize;
                    pPellet.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(7))
                {
                    GameObject tJunction = (GameObject)Instantiate(Resources.Load("TJunction"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    tJunction.transform.position = new Vector2(posX, posY);
                    RotateObject(tJunction, row, col, quad);
                }
                if (levelMap[row, col].Equals(8))
                {
                    GameObject bCherry = (GameObject)Instantiate(Resources.Load("BonusCherry"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    bCherry.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(9))
                {
                    GameObject pacman = (GameObject)Instantiate(Resources.Load("Pacman"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    pacman.transform.position = new Vector2(posX, posY);
                }
                if (levelMap[row, col].Equals(11))
                {
                    GameObject ghostN = (GameObject)Instantiate(Resources.Load("GhostNeon"), transform);
                    float posX = (col + yvar) * tileSize + startcol;
                    float posY = (row + xvar) * -tileSize + startrow;
                    ghostN.transform.position = new Vector2(posX, posY);
                }
            }
        }
        float GridH = levelMap.GetLength(0) * tileSize;
        float GridW = levelMap.GetLength(1) * tileSize;
        transform.position = new Vector2(-GridW / 2 + tileSize / 2, GridH / 2 - tileSize / 2);
    }

    private void RotateObject(GameObject obj, int row, int col, int quad)
    {
            int[,] mapAdjustment = {
        {0,3,3,3,3,3,3,3,3,3,3,3,3,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,3,3,3,0,0,3,3,3,3,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,1,1,2,0,1,1,1,1,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,3,3,3,0,0,3,0,0,3,3,3},
        {0,0,1,1,1,2,0,0,2,0,1,1,1,3},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,3,0,0,1,3,3,3,0,0},
        {0,0,0,0,0,2,0,0,0,1,1,2,0,1},
        {0,0,0,0,0,2,0,0,0,0,0,3,3,0},
        {1,1,1,1,1,2,0,1,2,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

            if (quad == 1)
            {
                if (mapAdjustment[row, col].Equals(1))
                {
                    obj.transform.Rotate(0f, 0f, 90f);
                }
                if (mapAdjustment[row, col].Equals(2))
                {
                    obj.transform.Rotate(0f, 0f, 180f);
                }
                if (mapAdjustment[row, col].Equals(3))
                {
                    obj.transform.Rotate(0f, 0f, 270f);
                }
                if (mapAdjustment[row, col].Equals(0))
                {
                    obj.transform.Rotate(0f, 0f, 0f);
                }
            }
            else if (quad == 2)
            {
                if (mapAdjustment[row, col].Equals(1))
                {
                    obj.transform.Rotate(0f, 0f, 90f);
                }
                if (mapAdjustment[row, col].Equals(2))
                {
                    obj.transform.Rotate(0f, 0f, 180f);
                }
                if (mapAdjustment[row, col].Equals(3))
                {
                    obj.transform.Rotate(0f, 0f, 270f);
                }
                if (mapAdjustment[row, col].Equals(4))
                {
                    obj.transform.Rotate(0f, 0f, 0f);
                }
            }
            else if (quad == 3)
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
                    obj.transform.Rotate(180f, 180f, 270f);
                }
                if (mapAdjustment[row, col].Equals(0))
                {
                    obj.transform.Rotate(180f, 180f, 0f);
                }
            }
            else if (quad == 4)
            {
                if (mapAdjustment[row, col].Equals(1))
                {
                    obj.transform.Rotate(270f, 270f, 90f);
                }
                if (mapAdjustment[row, col].Equals(2))
                {
                    obj.transform.Rotate(270f, 270f, 180f);
                }
                if (mapAdjustment[row, col].Equals(3))
                {
                    obj.transform.Rotate(270f, 270f, 270f);
                }
                if (mapAdjustment[row, col].Equals(0))
                {
                    obj.transform.Rotate(270f, 270f, 0f);
                }
            }
    }
}