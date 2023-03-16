using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    Vector2 direction = new Vector2(0, 0);
    [SerializeField] LayerMask wallLayer;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UIController uIController;
    bool isPlayerMoving = false;
    bool shouldMovePlayer = false;
    
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!uIController.isUIVisible) {
            UpdatePlayerDirection();
        } 
    }

    private void FixedUpdate() {
        if (shouldMovePlayer) {
            shouldMovePlayer = false;
            MovePlayer();
        }
    }

    void UpdatePlayerDirection() {
        if (!isPlayerMoving && Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector2.up;
            shouldMovePlayer = true;
        } else if (!isPlayerMoving && Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Vector2.left;
            shouldMovePlayer = true;
        } else if (!isPlayerMoving && Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Vector2.right;
            shouldMovePlayer = true;
        }
    }

    void MovePlayer() {
        isPlayerMoving = true;
        float moveDuration = 0f;
        Vector3 startPosition = transform.localPosition;
        Vector3 finalPosition = transform.localPosition;
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, direction, 40, wallLayer);
        if (hit2d.collider != null) {
            Vector2 colliderLocalPosition = hit2d.transform.localPosition;
            finalPosition.x = Mathf.RoundToInt(colliderLocalPosition.x - direction.x);
            finalPosition.y = Mathf.RoundToInt(colliderLocalPosition.y - direction.y);
        }
        direction = Vector2.zero;
        GameplayManager.Instance.PlayAudio(AudioType.PLAYER_DASH);
        while (moveDuration < Constants.MOVE_DURATION) {
            moveDuration += Time.fixedDeltaTime;
            transform.localPosition = Vector3.Lerp(startPosition, finalPosition, moveDuration / Constants.MOVE_DURATION);
        }
        transform.localPosition = new Vector3(Mathf.RoundToInt(finalPosition.x), Mathf.RoundToInt(finalPosition.y), 0f);
        isPlayerMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag(Constants.FIRE)) {
            // Game Over
            uIController.DisplayLevelFailed();
        }
    }
}
