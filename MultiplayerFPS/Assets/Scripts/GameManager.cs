/****************************************************
    文件：GameManager.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/11 16:48
	功能：游戏全局管理者
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string _netID, Player _player) {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public static void UnRegisterPlayer(string _playerID) {
        players.Remove(_playerID);
    }

    public static Player GetPlayer(string _playerID) {
        return players[_playerID];
    }


    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 300));
        GUILayout.BeginVertical();

        foreach (string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID + "  -  " + players[_playerID].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}