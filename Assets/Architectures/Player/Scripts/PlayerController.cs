using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private Vector2 _movement;

    private void Awake() {
        Initialization();
    }

    public void Initialization() {
        _moveSpeed = GetComponentInParent<Player>().MoveSpeed;
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Update() {
        RegisterInputs();
    }

    private void FixedUpdate() {
        Move();
        FlipFaceDirection();
    }

    private void RegisterInputs() {
        _movement = inputActions.Player.Move.ReadValue<Vector2>();
        if(_movement != Vector2.zero) {
            myAnimator.SetBool("Run", true);
        } else {
            myAnimator.SetBool("Run", false);
        }
    }

    private void Move() {
        rb.MovePosition(rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }

    private void FlipFaceDirection() {
        if (_movement.x < 0) {
            mySpriteRenderer.flipX = true;
        } else if (_movement.x > 0) {
            mySpriteRenderer.flipX = false;
        }
    }

    public void IncreaseSpeed(float value) {
        float increment = GetComponentInParent<Player>().MoveSpeed * value;
        _moveSpeed = Mathf.Clamp(_moveSpeed + increment, 0f, 50f);
    }
}
