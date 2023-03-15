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
    [SerializeField] Rigidbody2D greenPlayerRB;
    [SerializeField] Rigidbody2D bluePlayerRB;
    Transform greenPlayer;
    Transform bluePlayer;
    int maxLevels = 1;

    private void Awake() {
        greenPlayer = greenPlayerRB.gameObject.GetComponent<Transform>();
        bluePlayer = bluePlayerRB.gameObject.GetComponent<Transform>();
    }

    public bool isLevelComplete() {
        float greenDistance = Vector3.Distance(greenPlayer.position, greenLevelComplete.transform.position);
        float blueDistance = Vector3.Distance(bluePlayer.position, blueLevelComplete.transform.position);
        
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
        int nextSceneBuildIndex = (SceneManager.GetActiveScene().buildIndex + 1) % maxLevels;
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
