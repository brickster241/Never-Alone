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
        StartingScreenUI.SetActive(false);
        HowToPlayUI.SetActive(true);
    }

    public void DisplayLevelSelectUI() {
        StartingScreenUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }

    public void BackToStartingScreenUI() {
        HowToPlayUI.SetActive(false);
        LevelSelectUI.SetActive(false);
        StartingScreenUI.SetActive(true);
    }

    public void QuitApplication() {
        Application.Quit();
    }

    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }
}
