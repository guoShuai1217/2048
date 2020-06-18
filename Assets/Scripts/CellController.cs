/*
 *		Description: 
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using Console2048;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    const int row = 4, col = 4;

    private ItemCell[,] cellArr;

    private GameCore gameCore;

    private void Start()
    {
        gameCore = new GameCore();
        cellArr = new ItemCell[4, 4];

        initSprite();

        GenerateNewNumber();
        GenerateNewNumber();
    }

    #region init sprite

   
    void initSprite()
    {
       
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                createSprite(i,j);
            }
        }  
    }


    void createSprite(int row,int col)
    {
        GameObject tmp = new GameObject(row.ToString()+ col.ToString());
        tmp.AddComponent<Image>();
        ItemCell ic = tmp.AddComponent<ItemCell>();
        cellArr[row, col] = ic;

        ic.SetSprite(0);
        tmp.transform.SetParent(this.transform);
    }

    #endregion



    // 随机数 , 赋值UI
    void GenerateNewNumber()
    {
        Location loca;
        int num;
        gameCore.GenerateNumber(out loca, out num);

        cellArr[loca.RIndex, loca.CIndex].SetSprite(num);

    }


}