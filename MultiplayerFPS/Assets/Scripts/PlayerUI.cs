/****************************************************
    文件：PlayerUI.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/14 01:20
	功能：Player UI Canvas 管理
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour 
{
    [SerializeField]
    RectTransform thrusterFuelFill;

    [SerializeField]
    GameObject pauseMenu;

    private PlayerController controller;

    public void SetController(PlayerController _controller) {
        controller = _controller;
    }

    private void SetFuelAmount(float _amount)
    {
        thrusterFuelFill.localScale = new Vector3(1f,_amount,1f);
    }

    private void Start()
    {
        PauseMenu.IsOn = false;
    }

    private void Update()
    {
        SetFuelAmount(controller.GetThrusterFuelAmount());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }
}