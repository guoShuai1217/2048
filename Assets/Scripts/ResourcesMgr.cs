using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.scene4
{
    public static class ResourcesMgr
    {
        private static Dictionary<int, Sprite> sprDic;

        static ResourcesMgr()
        {
            sprDic = new Dictionary<int, Sprite>();
            Sprite[] tmpArr = Resources.LoadAll<Sprite>("Tex");
            for (int i = 0; i < tmpArr.Length; i++)
            {
                int key = int.Parse(tmpArr[i].name);
                sprDic.Add(key, tmpArr[i]);
            }
        }

        public static Sprite GetSprite(int num)
        {
            if (!sprDic.ContainsKey(num))
            {
                Debug.LogWarning("sprDic Not ContainsKey : " + num);
                return null;
            }

            return sprDic[num];
        }

    }
}
