using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _difficultyText;
    [SerializeField] GameObject[] _descriptions;
    int _difficulty;

    private void Start()
    {
        _difficulty = 0;
    }

    public void ChangeDifficulty(int increment)
    {
        _difficulty += increment;
        if (_difficulty > 2)
        {
            _difficulty = 0;
        }
        else if (_difficulty < 0)
        {
            _difficulty = 2;
        }
        ChangeDifficultyText();
        ChangeDescription();
    }

    void ChangeDifficultyText()
    {
        var newText = "";
        switch (_difficulty)
        {
            case 0:
                newText = "Normal";
                break;
            case 1:
                newText = "Hard";
                break;
            case 2:
                newText = "Timed";
                break;
            default:
                newText = "Normal";
                break;
        }
        _difficultyText.text = newText;
    }

    public void SetDifficulty()
    {
        switch (_difficulty)
        {
            case 0:
                SceneManager.LoadScene("Game");
                break;
            case 1:
                SceneManager.LoadScene("Game 2");
                break;
            case 2:
                SceneManager.LoadScene("Game 3");
                break;
            default:
                SceneManager.LoadScene("Game");
                break;
        }
    }

    void ChangeDescription()
    {
        switch (_difficulty)
        {
            case 0:
                _descriptions[0].SetActive(true);
                _descriptions[1].SetActive(false);
                _descriptions[2].SetActive(false);
                break;
            case 1:
                _descriptions[0].SetActive(false);
                _descriptions[1].SetActive(true);
                _descriptions[2].SetActive(false);
                break;
            case 2:
                _descriptions[0].SetActive(false);
                _descriptions[1].SetActive(false);
                _descriptions[2].SetActive(true);
                break;
            default:
                _descriptions[0].SetActive(true);
                _descriptions[1].SetActive(false);
                _descriptions[2].SetActive(false);
                break;
        }
    }
}
