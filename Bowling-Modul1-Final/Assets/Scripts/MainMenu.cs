using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI highScoreText;
    [SerializeField] private TMP_InputField nameInput;

    [Header("Variables")]
    public bool isOption = false;


    private void Awake()
    {
        nameInput.onEndEdit.AddListener(delegate { ChangeName(nameInput.text); });
    }

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore")  + PlayerPrefs.GetString("PlayerName");
    }

    public void ChangeName(string newName)
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
