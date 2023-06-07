using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseWindow;

    public void ChangePauseWindowState(bool isPaused)
    {
        if (isPaused)
        {
            _pauseWindow.SetActive(true);
        }
        else
        {
            _pauseWindow.SetActive(false);
        }
    }
}
