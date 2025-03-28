using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _movementDirection;
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;

    private void Awake() {
        Initialization();
    }

    private void Initialization()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        rb.MovePosition(transform.position + _movementDirection * _speed * Time.fixedDeltaTime);
    }

    public void MoveTo(Vector3 movementDirection) {
        _movementDirection = movementDirection;
    }

    private void FlipFaceDirection() {
        if (_movementDirection.x < 0) {
            mySpriteRenderer.flipX = true;
        } else if (_movementDirection.x > 0) {
            mySpriteRenderer.flipX = false;
        }
    }
}
