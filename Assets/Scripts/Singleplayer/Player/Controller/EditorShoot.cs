using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorShoot : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Inventory>().UseWeapon();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Inventory>().UseWeapon();
        }
    }
#endif
}
