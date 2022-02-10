using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //����� ������� ������� ������
    [SerializeField]
    private Weapon currentWeapon;

    public void UseWeapon()
    {
        currentWeapon.InvokeFire();
    }

    private void Awake()
    {

    }

    private void Update()
    {

    }

    private void Shoot()
    {
        AudioManager.Instance.PlaySound(SoundType.Shot);
    }
}
