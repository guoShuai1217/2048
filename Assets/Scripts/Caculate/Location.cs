/*
 *		Description: 
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

namespace Console2048
{


    //定义 移动方向 枚举类型
    public enum MoveDirection : int
    {
        //******定义值*******
        Up,
        Down,
        Left,
        Right
    }


    /// <summary>
    /// 位置
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// 行索引
        /// </summary>
        public int RIndex { get; set; }

        /// <summary>
        /// 列索引
        /// </summary>
        public int CIndex { get; set; }

        public Location(int r, int c) : this()
        {
            this.RIndex = r;
            this.CIndex = c;
        }
    }
}