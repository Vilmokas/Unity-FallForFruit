using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    [SerializeField] GameObject _pauseWindow;
    [SerializeField] GameObject _gameOverWindow;
    [SerializeField] List<GameObject> _heartIcons;
    [SerializeField] GameObject _objectPositionIndicator;
    [SerializeField] float _objectPosIndicatorLifetime;
    [SerializeField] TextMeshProUGUI _countdownText;
    GameObject _canvas;

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
        _canvas = GameObject.Find("Canvas");
    }

    public void ShowObjectIndicator(GameObject target)
    {
        StartCoroutine(CreateObjectIndicator(target));
    }

    IEnumerator CreateObjectIndicator(GameObject target)
    {
        var indicator = Instantiate(_objectPositionIndicator, _canvas.transform);
        indicator.GetComponent<Indicator>().Target = target;
        yield return new WaitForSeconds(_objectPosIndicatorLifetime);
        Destroy(indicator);
    }

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

    public void ChangeHealth(int health)
    {
        foreach (var icon in _heartIcons)
        {
            icon.SetActive(true);
        }
        for (var i = _heartIcons.Count - health; i > 0; i--)
        {
            _heartIcons[i - 1].SetActive(false);
        }
    }

    public void ChangeGameOverWindowState(bool isGameOver)
    {
        if (isGameOver)
        {
            _gameOverWindow.SetActive(true);
        }
        else
        {
            _gameOverWindow.SetActive(false);
        }
    }

    public void ChangeCountdownText(string text)
    {
        if (text == "hide")
        {
            _countdownText.gameObject.SetActive(false);
        }
        _countdownText.text = text;
    }

    public void RestartGame()
    {
        GameManager.Instance.OnGameRestart();
    }
}
