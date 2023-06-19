using UnityEngine;

public class TutorialManager : MonoBehaviour
{
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
}
