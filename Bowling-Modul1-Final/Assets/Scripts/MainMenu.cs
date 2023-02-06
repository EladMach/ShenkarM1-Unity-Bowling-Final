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
    [SerializeField] private TMP_InputField name2Input;

    [Header("Variables")]
    public bool isOption = false;


    private void Awake()
    {
        nameInput.onEndEdit.AddListener(delegate { ChangeName(nameInput.text); });
        nameInput.onEndEdit.AddListener(delegate { ChangeName(name2Input.text); });
    }

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore")  + PlayerPrefs.GetString("Player1Name");

        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore") + PlayerPrefs.GetString("Player2Name");
    }

    public void ChangeName(string newName)
    {
        PlayerPrefs.SetString("Player1Name", nameInput.text);
        PlayerPrefs.SetString("Player2Name", name2Input.text);
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
