/****************************************************
    文件：Util.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/14 00:10
	功能：工具类
*****************************************************/


using UnityEngine;

public class Util  
{

    //递归设置Go的层级
    public static void SetLayerRecursively(GameObject _obj, int _newLayer) {
        if (_obj == null)
            return;

        _obj.layer = _newLayer;

        foreach (Transform _child in _obj.transform)
        {
            if (_child == null)
                continue;

            SetLayerRecursively(_child.gameObject,_newLayer);
        }
    }
}