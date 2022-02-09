using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupCreator : MonoBehaviour
{
    public static DamagePopupCreator Instance { get; private set; }

    public GameObject DamageText;

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    public void CreateText(Vector3 position)
    {
        Instantiate(DamageText, position, Quaternion.identity);
    }
}
