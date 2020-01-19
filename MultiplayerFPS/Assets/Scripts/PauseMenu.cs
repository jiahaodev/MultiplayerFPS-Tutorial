/****************************************************
    文件：PauseMenu.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/19 11:41
	功能：暂停，退出游戏的菜单
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenu : MonoBehaviour 
{
    public static bool IsOn = false;

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
    }

    public void LeaveRoom() {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDestroyMatch);
        networkManager.StopHost();
    }


}