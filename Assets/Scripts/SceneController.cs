using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }

    public void OnDifficultyScene()
    {
        if (GetTutorialStatus())
        {
            SceneManager.LoadScene("Difficulty");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    bool GetTutorialStatus()
    {
        var playerSettings = GetSettingsData();

        if (playerSettings == null)
        {
            return false;
        }

        return playerSettings.IsTutorialCompleted;
    }

    PlayerSettings GetSettingsData()
    {
        var path = Application.persistentDataPath + "/playerSettings.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<PlayerSettings>(json);
            return data;
        }

        return null;
    }

    public void SavePlayerData()
    {
        var data = new PlayerSettings();
        data.IsTutorialCompleted = true;

        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerSettings.json", json);
    }
}

[Serializable]
public class PlayerSettings
{
    public bool IsTutorialCompleted;
}

