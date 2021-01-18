using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce = 8;
    public float runningSpeed = 20;
    Rigidbody2D rigidBody;
    public LayerMask groundMask;
    Animator animator;
    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";
    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, false);
        animator.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingTheGround()) {
            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, isTouchingTheGround());
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            GetComponent<SpriteRenderer>().flipX = true;
            rigidBody.velocity = new Vector2(-runningSpeed, rigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            GetComponent<SpriteRenderer>().flipX = false;
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }

    }


    public void Jump() {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool isTouchingTheGround() {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask)) {
            animator.enabled = true;
            return true;
        }
        else {
            animator.enabled = false;
            return false;
        }
    }
}