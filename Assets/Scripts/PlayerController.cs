using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    Vector2 direction = new Vector2(0, 0);
    float tileSize = 2f;
    bool isPlayerMoving = false;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }


    private void Update() {
        UpdatePlayerDirection();
        if (!isPlayerMoving)
            direction = new Vector2(0, 0);
    }

    void UpdatePlayerDirection() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isPlayerMoving) {
            isPlayerMoving = true;
            direction = Vector2.up;
            StartCoroutine(GoInDirection());
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && !isPlayerMoving) {
            isPlayerMoving = true;
            direction = Vector2.down;
            StartCoroutine(GoInDirection());
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isPlayerMoving) {
            isPlayerMoving = true;
            direction = Vector2.left;
            StartCoroutine(GoInDirection());
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && !isPlayerMoving) {
            isPlayerMoving = true;
            direction = Vector2.right;
            StartCoroutine(GoInDirection());
        }
    }


    IEnumerator GoInDirection() {
        yield return new WaitForSeconds(1f);
        direction = new Vector2(0, 0);
        isPlayerMoving = false;
    }

    private void FixedUpdate() {
        Vector3 position = transform.position;
        position.x = Mathf.Round(position.x + direction.x);
        position.y = Mathf.Round(position.y + direction.y);
        transform.position = position;
    }
}
