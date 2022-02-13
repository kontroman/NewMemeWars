using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    public GameObject window;

    public void Call()
    {
        window.SetActive(true);
    }

    public void Close()
    {
        window.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Close();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Close();
    }
}
