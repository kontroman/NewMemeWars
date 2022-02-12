using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWheel : MonoBehaviour
{
    
    public Inventory player;

    [SerializeField] private GameObject wheel1;
    [SerializeField] private GameObject wheel2;
    [SerializeField] private GameObject wheel3;

    public void SetWheelVisible(bool _bool)
    {
        StartCoroutine(WaitForWheels(_bool));
        
        //wheel1.SetActive(_bool);
        //wheel2.SetActive(_bool);
        //wheel3.SetActive(_bool);
    }

    IEnumerator WaitForWheels(bool _bool)
    {
        yield return new WaitForSeconds(0.05f);
        wheel1.SetActive(_bool);
        wheel2.SetActive(_bool);
        wheel3.SetActive(_bool);
    }

    public void SelectGun(Weapon weapon)
    {
        player.SetNewWeapon(weapon);
    }

    //TODO: disable wheels

    public void TestPointerEnter()
    {
        Debug.Log("Mouse on object");
    }

    public void TestPointerUp()
    {
        Debug.Log("Weapon selected");
        SetWheelVisible(false);
    }
}
