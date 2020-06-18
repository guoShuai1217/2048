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
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MoveDirection = Console2048.MoveDirection;

public class CellController : MonoBehaviour ,IDragHandler,IBeginDragHandler
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

        ItemCell tmpCell = cellArr[loca.RIndex, loca.CIndex];
        tmpCell.SetSprite(num);
        tmpCell.PlayEffect();

    }


    private void Update()
    {
        // 如果地图有更新
        if (gameCore.IsChange)
        {
            UpdateMap();// 更新界面

            GenerateNewNumber(); // 产生新数字

            bool result = gameCore.IsOver();
            if (result)
            {
                Debug.Log("Game Over");

            }

            gameCore.IsChange = false;
        }




    }

    // 更新界面
    private void UpdateMap()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                cellArr[i, j].SetSprite(gameCore.Map[i, j]);
            }
        }
    }


    // 开始拖拽的点
    private Vector2 startPoint; 
    private bool isDown = false;


    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.position;
        isDown = true;
    }


    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!isDown) return;

        Vector2 offset = eventData.position - startPoint;

        float x = Mathf.Abs(offset.x);
        float y = Mathf.Abs(offset.y);

        MoveDirection? dir = null;

        if(x > y && x >= 50) // |x| > |y| 左右拖拽
        {
            // x > 0 向右拖拽,x < 0 向左拖拽
            dir = offset.x > 0 ? MoveDirection.Right : MoveDirection.Left;

        }
 
        if(x < y && y >= 50) // |x| < |y| 上下拖拽
        {
            // y > 0  向上拖拽 ,y < 0 向下拖拽
            dir = offset.y > 0 ? MoveDirection.Up : MoveDirection.Down;
        }

        if(dir != null)
        {
            gameCore.Move(dir.Value);
            isDown = false;
        }
      
    }


}