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
    public bool isUIVisible;
    Image PauseButtonTop;

    private void Start() {
        isUIVisible = false;
        PauseButtonTop = PauseButtonText.GetComponentInParent<Image>();
    }
    
    public void OnPauseButtonClick() {
        if (isUIVisible)
            return;
        isUIVisible = true;
        PauseButtonTop.color = Color.yellow;
        PauseButtonText.text = "PAUSED";
        PauseUI.SetActive(true);
    }

    public void OnResumeButtonClick() {
        isUIVisible = false;
        PauseUI.SetActive(false);
        PauseButtonTop.color = Color.green;
        PauseButtonText.text = "PAUSE";
    
    }

    public void DisplayLevelComplete() {
        isUIVisible = true;
        LevelCompleteUI.SetActive(true);
    }

    public void OnRestartButtonClick() {
        levelManager.RestartLevel();
    }

    public void OnMainMenuButtonClick() {
        levelManager.GoToMainMenu();
    }

    public void OnNextButtonClick() {
        levelManager.LoadNextLevel();
    }
}
