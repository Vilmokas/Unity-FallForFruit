using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] float _timeLeft;
    SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _timerText.text = _timeLeft.ToString();
        StartCoroutine(StartTimerCoroutine());
    }

    IEnumerator StartTimerCoroutine()
    {
        yield return new WaitForSeconds(_spawnManager.SpawnDelay);
        while (_timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeLeft -= 1f;
            _timerText.text = _timeLeft.ToString();
        }
        GameManager.Instance.OnGameOver();
        UIManager.Instance.ChangeGameOverWindowState(true);
    }
}
