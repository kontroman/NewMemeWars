using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Нужно хранить текущее оружие
    [SerializeField]
    private Weapon currentWeapon;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void Shoot()
    {
        AudioManager.Instance.PlaySound(SoundType.Shot);
    }
}
