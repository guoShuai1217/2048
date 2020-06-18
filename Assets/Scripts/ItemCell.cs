/*
 *		Description: 
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using Assets.Scripts.scene4;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{

    // 移动,合并,更换换sprite

    private Image ima;
    private void Awake()
    {
        ima = GetComponent<Image>();
    }

    /// <summary>
    /// Sprite 赋值
    /// </summary>
    /// <param name="num"></param>
    public void SetSprite(int num)
    {
        Sprite tmp = ResourcesMgr.GetSprite(num);
        setSprite(tmp);
    }


    /// <summary>
    /// 播放特效
    /// </summary>
    public void PlayEffect()
    {

    }


    void setSprite(Sprite spr)
    {
        ima.sprite = spr;
    }
    
}