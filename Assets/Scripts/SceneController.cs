using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }

    public void OnDifficultyScene()
    {
        SceneManager.LoadScene("Difficulty");
    }
}
