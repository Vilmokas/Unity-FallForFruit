using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    [SerializeField] GameObject _pauseWindow;
    [SerializeField] GameObject _gameOverWindow;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] GameObject _objectPositionIndicator;
    [SerializeField] float _objectPosIndicatorLifetime;
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

    public void ChangeHealthText(int health)
    {
        _healthText.text = health.ToString();
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

    public void RestartGame()
    {
        GameManager.Instance.OnGameRestart();
    }
}
