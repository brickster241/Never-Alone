using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject greenLevelComplete;
    [SerializeField] GameObject blueLevelComplete;
    [SerializeField] Rigidbody2D greenPlayerRB;
    [SerializeField] Rigidbody2D bluePlayerRB;
    public bool isLevelOver = false;

    void Start() {
        isLevelOver = false;
        StartCoroutine(EnableAndDisableGravity());
    }

    IEnumerator EnableAndDisableGravity() {
        while (!isLevelOver) {
            greenPlayerRB.gravityScale = 3;
            bluePlayerRB.gravityScale = 3;
            yield return new WaitForSeconds(Constants.DISABLE_ENABLE_GRAVITY_INTERVAL);
            greenPlayerRB.gravityScale = 0;
            bluePlayerRB.gravityScale = 0;
            yield return new WaitForSeconds(Constants.DISABLE_ENABLE_GRAVITY_INTERVAL);
        }
    }
}
