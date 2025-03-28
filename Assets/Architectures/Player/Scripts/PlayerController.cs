using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private Vector2 movement;

    private void Awake() {
        Initialization();
    }

    private void Initialization() {
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();
    }

    private void Update() {
        RegisterInputs();
    }

    private void FixedUpdate() {
        Move();
        FlipFaceDirection();
    }

    private void RegisterInputs() {
        movement = inputActions.Player.Move.ReadValue<Vector2>();
        if(movement != Vector2.zero) {
            myAnimator.SetBool("Run", true);
        } else {
            myAnimator.SetBool("Run", false);
        }
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }

    private void FlipFaceDirection() {
        if (movement.x < 0) {
            mySpriteRenderer.flipX = true;
        } else if (movement.x > 0) {
            mySpriteRenderer.flipX = false;
        }
    }
}
