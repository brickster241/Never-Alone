using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject StartingScreenUI;
    [SerializeField] GameObject HowToPlayUI;
    [SerializeField] GameObject LevelSelectUI;

    public void DisplayHowToPlayUI() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        StartingScreenUI.SetActive(false);
        HowToPlayUI.SetActive(true);
    }

    public void DisplayLevelSelectUI() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        StartingScreenUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }

    public void BackToStartingScreenUI() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        HowToPlayUI.SetActive(false);
        LevelSelectUI.SetActive(false);
        StartingScreenUI.SetActive(true);
    }

    public void QuitApplication() {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        Application.Quit();
    }

    public void LoadLevel(int level) {
        GameplayManager.Instance.PlayAudio(AudioType.BUTTON_CLICK);
        SceneManager.LoadScene(level);
    }
}
