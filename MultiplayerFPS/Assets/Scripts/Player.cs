/****************************************************
    文件：Player.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/11 16:48
	功能：玩家对应类
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{
    [SerializeField]
    private int maxHealth = 100;
    [SyncVar]
    private int currentHealth;

    private void Awake()
    {
        SetDefaults();
    }

    public void TakeDamage(int _amount) {
        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health.");
    }

    private void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}