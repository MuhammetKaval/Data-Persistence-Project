using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using Unity.IO;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public GameObject InputField;
    public GameObject MenuBestScore;

    private void Start()
    {
        InputField.GetComponent<TMP_InputField>().text = GameManager.Instance.BestPlayerName;
        MenuBestScore.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.BestScoreText;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void GetName()
    {
        GameManager.Instance.NameText = InputField.GetComponent<TMP_InputField>().text;
    }

    

}
