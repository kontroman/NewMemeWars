using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : Singleton<StopGame>
{
    [SerializeField]
    private GameObject player;

    public bool GameInProgress = true;

    private void OnEnable()
    {
        GetComponent<GameTimer>().onGameStopAction += StopGameHandler;
    }

    private void OnDisable()
    {
        GetComponent<GameTimer>().onGameStopAction -= StopGameHandler;
    }

    public void StopGameHandler()
    {
        GameInProgress = false;
        Camera.main.GetComponent<EditorCamera>().enabled = false;
        player.GetComponent<EditorMovement>().enabled = false;
    }
}
