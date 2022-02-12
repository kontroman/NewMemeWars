using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolesController : MonoBehaviour
{
    public static BulletHolesController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    private void Init()
    {
        //Надо пул объектов замутить что бы не было напряга по производительности в мультиплеере
    }

}
