using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool paused;

    FinishLine finishLine;
    private void Awake()
    {
        finishLine = FindObjectOfType<FinishLine>();
    }
    private void Start()
    {
        paused = false;
    }
    private void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            if (finishLine.finishGame) return;
            Time.timeScale = 1;
        }
    }
    public void ShowPausePanel()
    {
        UIController.Instance.ShowPausePanel();
        paused = true;
    }
    public void HidePausePanel()
    {
        UIController.Instance.HidePausePanel();
        paused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
