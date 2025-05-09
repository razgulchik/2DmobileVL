using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Enemy _enemyComponent;
    private float _moveSpeed;
    private Vector3 _movementDirection;
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    //private Animator myAnimator;

    private void Awake() {
        _enemyComponent = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        _moveSpeed = _enemyComponent.MoveSpeed;
        //myAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        Move();
        FlipFaceDirection();
    }

    private void Move() {
        rb.MovePosition(transform.position + _movementDirection * _moveSpeed * Time.fixedDeltaTime);
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
