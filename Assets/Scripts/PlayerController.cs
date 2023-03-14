using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    float speed = 2f;
    Vector2 direction = Vector2.right;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        

    }
    
}
