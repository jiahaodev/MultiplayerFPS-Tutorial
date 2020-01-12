/****************************************************
    文件：WeaponManager.cs
	作者：JiahaoWu
    邮箱: jiahaodev@163.com
    日期：2020/01/13 01:31
	功能：武器管理
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour 
{
    [SerializeField]
    private string weaponLayerName = "Weapon";

    [SerializeField]
    private Transform weaponHolder;

    [SerializeField]
    private PlayerWeapon primaryWeapon;

    private PlayerWeapon currentWeapon;

    private void Start()
    {
        EquipWeapon(primaryWeapon);
    }

    public PlayerWeapon GetCurrentWeapon() {
        return currentWeapon;
    }

    private void EquipWeapon(PlayerWeapon _weapon) {
        currentWeapon = _weapon;

        GameObject _weaponIns = Instantiate(_weapon.graphics,weaponHolder.position,weaponHolder.rotation);
        _weaponIns.transform.SetParent(weaponHolder);

        if (isLocalPlayer)
            _weaponIns.layer = LayerMask.NameToLayer(weaponLayerName);
    }

}