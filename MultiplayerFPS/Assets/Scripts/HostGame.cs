/****************************************************
    文件：HostGame.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/19 09:56
	功能：用于创建房间
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour
{
    [SerializeField]
    private uint roomSize = 6;

    private string roomName;

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    //监听OnValueChanged没有搜到正确字符，改为监听OnEndEdit
    public void SetRoomName(string _name)
    {
        //Debug.Log("SetRoomName :" + _name);
        roomName = _name;
    }

    public void CreateRoom()
    {
        //Debug.Log("roomName :" + roomName);
        if (string.IsNullOrEmpty(roomName)) {
            string timeStr = DateTime.Now.Ticks.ToString();
            roomName = "default" + timeStr;

            Debug.Log("roomName :" + roomName);
        
        }

        if (roomName != "" && roomName != null)
        {
            Debug.Log("Create Room: " + roomName + " with room for " + roomSize + " players.");
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }

}