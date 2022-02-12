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

    public void SetNewWeapon(Weapon _weapon)
    {
        currentWeapon = _weapon;
        Debug.Log("New weapon equiped");
    }

}
