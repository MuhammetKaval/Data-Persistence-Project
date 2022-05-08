using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string BestScoreText;
    public string NameText;
    public string BestPlayerName;
    public int BestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RestartData();
            LoadBestScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    class SaveData
    {
        public string _bestScoreText;
        public string _bestName;
        public int _bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData
        {
            _bestScoreText = $"Best Score: {Instance.NameText}: {Instance.BestScore}",
            _bestScore = Instance.BestScore,
            _bestName = Instance.NameText
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instance.BestScoreText = data._bestScoreText;
            Instance.BestScore = data._bestScore;
            Instance.BestPlayerName = data._bestName;
        }
    }

    public void RestartData()
    {
        SaveData restartData = new SaveData
        {
            _bestScoreText = $"Best Score: {""}: {0}",
            _bestScore = 0,
            _bestName = ""
        };

        string restartjson = JsonUtility.ToJson(restartData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", restartjson);
    }
}
