using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _currentHealth = 3;
    UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _uiManager.ChangeHealthText(_currentHealth);
    }

    public void ReduceHealth(int reduceAmount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - reduceAmount, 0, _currentHealth);
        _uiManager.ChangeHealthText(_currentHealth);

        if (_currentHealth == 0)
        {
            GameManager.Instance.OnGameOver();
            _uiManager.ChangeGameOverWindowState(true);
        }
    }
}
