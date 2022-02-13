using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreBoard : Singleton<ScoreBoard>
{
    public Dictionary<string, int> scoreboard = new Dictionary<string, int>();

    [SerializeField] GameTimer timer;

    private void OnEnable()
    {
        timer.onGameStopAction += OnGameStopHandler;
    }

    private void OnDisable()
    {
        timer.onGameStopAction -= OnGameStopHandler;
    }

    private void OnGameStopHandler()
    {
        //Debug.LogError("Winner has " + GetLeaderScore() + " kills!");
    }

    public void AddNewPlayer(string playerName)
    {
        scoreboard.Add(playerName, 0);
    }

    public void AddPlayerScore(string playerName, int score)
    {
        scoreboard[playerName] += score;
    }

    public void CollectScore(GameObject player)
    {
        scoreboard[player.name] += 1;
    }

    public int GetLeaderScore()
    {
        var ordered = scoreboard.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        var first = ordered.First();
        var key = first.Key;
        return ordered[key];
    }
}
