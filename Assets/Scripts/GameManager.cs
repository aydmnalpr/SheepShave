using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public GameObject winUI;

    private void OnEnable()
    {
        Shaver.OnGameWin += ShowWinUI;
    }

    private void OnDisable()
    {
        Shaver.OnGameWin -= ShowWinUI;
    }

    void ShowWinUI()
    {
        winUI.SetActive(true);
    }

    public void RestartGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
