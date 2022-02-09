using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float Delay;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }


}
