using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject LevelCompleteUI;
    [SerializeField] GameObject LevelFailedUI;
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
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        PauseButtonTop.color = Color.yellow;
        PauseButtonText.text = "PAUSED";
        PauseUI.SetActive(true);
    }

    public void OnResumeButtonClick() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        isUIVisible = false;
        PauseUI.SetActive(false);
        PauseButtonTop.color = Color.green;
        PauseButtonText.text = "PAUSE";
    
    }

    public void DisplayLevelComplete() {
        GameplayManager.Instance.PlayAudio(AudioType.LEVEL_COMPLETE);
        isUIVisible = true;
        LevelCompleteUI.SetActive(true);
    }

    public void DisplayLevelFailed() {
        GameplayManager.Instance.PlayAudio(AudioType.LEVEL_OVER);
        isUIVisible = true;
        LevelFailedUI.SetActive(true);
    }

    public void OnRestartButtonClick() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        levelManager.RestartLevel();
    }

    public void OnMainMenuButtonClick() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        levelManager.GoToMainMenu();
    }

    public void OnNextButtonClick() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        levelManager.LoadNextLevel();
    }

    private void FixedUpdate() {
        bool isLevelCompleted = levelManager.isLevelComplete();
        if (isLevelCompleted && !isUIVisible) {
            int currentMaxLevel = Mathf.Max(PlayerPrefs.GetInt(Constants.UNLOCKED_LEVEL), (SceneManager.GetActiveScene().buildIndex + 1) % GameplayManager.Instance.TotalScenes);
            PlayerPrefs.SetInt(Constants.UNLOCKED_LEVEL, currentMaxLevel);
            DisplayLevelComplete();
        }
    }
}
