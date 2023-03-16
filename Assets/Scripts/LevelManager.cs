using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject greenLevelComplete;
    [SerializeField] GameObject blueLevelComplete;
    [SerializeField] GameObject GreenPlayer;
    [SerializeField] GameObject BluePlayer;

    public bool isLevelComplete() {
        float greenDistance = Vector3.Distance(GreenPlayer.transform.localPosition, greenLevelComplete.transform.localPosition);
        float blueDistance = Vector3.Distance(BluePlayer.transform.localPosition, blueLevelComplete.transform.localPosition);
        
        return greenDistance < Constants.MIN_DISTANCE && blueDistance < Constants.MIN_DISTANCE;
    }

    public void RestartLevel() {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(Constants.MAIN_MENU_BUILD_INDEX);
    }

    public void LoadNextLevel() {
        int nextSceneBuildIndex = (SceneManager.GetActiveScene().buildIndex + 1) % GameplayManager.Instance.TotalScenes;
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
