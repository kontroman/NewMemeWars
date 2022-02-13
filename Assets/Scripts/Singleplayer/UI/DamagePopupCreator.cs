using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopupCreator : MonoBehaviour
{
    public static DamagePopupCreator Instance { get; private set; }

    public GameObject DamageText;

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    public void CreateText(Vector3 position, float weaponDamage)
    {
        GameObject text = Instantiate(DamageText, position, Quaternion.identity);
        text.transform.GetChild(0).GetComponent<Text>().text = "" + weaponDamage;
    }
}
