using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    bool _isGamePaused;
    public bool IsGamePaused { get { return _isGamePaused; } }
    bool _isGameOver;
    public bool IsGameOver { get { return _isGameOver; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _isGamePaused = false;
        _isGameOver = false;
    }

    public void PauseGame(bool isGamePaused)
    {
        _isGamePaused = isGamePaused;
        if (_isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnGameOver()
    {
        _isGameOver = true;
    }

    public void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
