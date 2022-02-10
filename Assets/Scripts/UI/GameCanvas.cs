using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance { get; private set; }

    public Text roundTimeText;
    public Text AmmoText;

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
    }

    public void UpdateRoundTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        roundTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateAmmoText(int ammo)
    {
        AmmoText.text = "" + ammo;
    }
}
