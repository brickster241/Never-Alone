using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject LevelCompleteUI;
    [SerializeField] LevelManager levelManager;
    [SerializeField] TextMeshProUGUI PauseButtonText;
    Image PauseButtonTop;

    private void Start() {
        PauseButtonTop = PauseButtonText.GetComponentInParent<Image>();
    }
    
    public void OnPauseButtonClick() {
        PauseButtonTop.color = Color.yellow;
        PauseButtonText.text = "PAUSED";
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButtonClick() {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        PauseButtonTop.color = Color.green;
        PauseButtonText.text = "PAUSE";
    }

    public void OnRestartButtonClick() {
        Time.timeScale = 1f;
        levelManager.RestartLevel();
    }

    public void OnMainMenuButtonClick() {
        Time.timeScale = 1f;
        levelManager.GoToMainMenu();
    }

    public void OnNextButtonClick() {
        Time.timeScale = 1f;
        levelManager.LoadNextLevel();
    }
}
