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
    
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!uIController.isUIVisible) {
            UpdatePlayerDirectionMovement();
        } 
    }

    void UpdatePlayerDirectionMovement() {
        if (!isPlayerMoving && Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector2.up;
            isPlayerMoving = true;
            MovePlayer();
        } else if (!isPlayerMoving && Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Vector2.left;
            isPlayerMoving = true;
            MovePlayer();
        } else if (!isPlayerMoving && Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Vector2.right;
            isPlayerMoving = true;
            MovePlayer();
        }
    }

    void MovePlayer() {
        float moveDuration = 0f;
        Vector3 startPosition = transform.localPosition;
        Vector3 finalPosition = transform.localPosition;
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, direction, 40, wallLayer);
        if (hit2d.collider != null) {
            Vector2 colliderLocalPosition = hit2d.transform.localPosition;
            finalPosition.x = Mathf.RoundToInt(colliderLocalPosition.x - direction.x);
            finalPosition.y = Mathf.RoundToInt(colliderLocalPosition.y - direction.y);
        }
        GameplayManager.Instance.PlayAudio(AudioType.PLAYER_DASH);
        while (moveDuration < Constants.MOVE_DURATION) {
            moveDuration += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPosition, finalPosition, moveDuration / Constants.MOVE_DURATION);
        }
        transform.localPosition = new Vector3(Mathf.RoundToInt(finalPosition.x), Mathf.RoundToInt(finalPosition.y), 0f);
        isPlayerMoving = false;
    }
}
