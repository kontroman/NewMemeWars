using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private float roundTime;
    private bool paused = true;

    [SerializeField]
    UnityEvent onGameStop;

    public event Action onGameStopAction;

    private void Awake()
    {
        SetPause(false);
    }

    public void SetPause(bool _bool)
    {
        paused = _bool;
    }

    private void Update()
    {
        if (paused) return;

        roundTime -= Time.deltaTime;

        if (roundTime <= 0)
        {
            SetPause(true);
            onGameStop.Invoke();

            if (onGameStopAction != null)
                onGameStopAction();

            return;
        }

        GameCanvas.Instance.UpdateRoundTime(roundTime);
    }
}
