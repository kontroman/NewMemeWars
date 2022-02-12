using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCount : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        Application.targetFrameRate = 500;
    }

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "FPS: " + (int)(1.0f / Time.deltaTime);
    }
}
