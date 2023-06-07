using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    GameManager _gameManager;
    PlayerController _playerController;
    UIManager _UIManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _UIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _playerController.SetDirection(context.ReadValue<float>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        _gameManager.PauseGame(!_gameManager.IsGamePaused);
        _UIManager.ChangePauseWindowState(!_gameManager.IsGamePaused);
    }
}
