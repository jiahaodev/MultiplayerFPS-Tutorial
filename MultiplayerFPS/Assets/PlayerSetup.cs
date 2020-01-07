/****************************************************
    文件：PlayerSetup.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/07 23:42
	功能：启动时设置玩家，动态设置Player组件的启动/禁用
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour 
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;

    private void Start()
    {
        //Disable components that should only be
        //active on the player that we control
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera !=null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    //when we are destroyed
    private void OnDisable()
    {
        //Re-enable the scene camera
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(false);
        }
    }


}