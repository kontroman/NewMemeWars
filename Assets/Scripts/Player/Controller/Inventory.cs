using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Нужно хранить текущее оружие
    [SerializeField]
    private Weapon currentWeapon;

    public void UseWeapon()
    {
        currentWeapon.InvokeFire();
    }

    private void Awake()
    {
        HealthManager.Instance.DecreaseHealth(2);
    }

    private void Update()
    {

    }

    private void Shoot()
    {
        AudioManager.Instance.PlaySound(SoundType.Shot);
    }
}
