using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseWindow;
    [SerializeField] TextMeshProUGUI _healthText;

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

    public void ChangeHealthText(int health)
    {
        _healthText.text = health.ToString();
    }
}
