using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _tutorialBoards;
    [SerializeField] GameObject _spawnManager;
    [SerializeField] GameObject _startTimer;
    int _currentTutorialBoard = 0;

    private void Update()
    {
        SaveTutorialSettings();
    }

    void SaveTutorialSettings()
    {
        if (GameManager.Instance == null)
        {
            return;
        }

        if (GameManager.Instance.IsGameOver)
        {
            var sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneController>();
            sceneManager.SavePlayerData();
        }
    }

    public void ChangeDisplayBoard()
    {
        _tutorialBoards[_currentTutorialBoard].SetActive(false);
        _currentTutorialBoard++;
        if (_currentTutorialBoard < _tutorialBoards.Count)
        {
            _tutorialBoards[_currentTutorialBoard].SetActive(true);
        }
        else
        {
            _startTimer.SetActive(true);
            _spawnManager.SetActive(true);
        }
    }
}
