using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Общие настройки")]
    [SerializeField] private PickupType pickupType;
    [SerializeField] private float magnetDistance = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float acceleration = 0.4f;
    [Header("Конкретные настройки")]
    [SerializeField] private int _expAmount = 1;
    [SerializeField] private int _healAmount = 1;

    private Rigidbody2D _rb;
    private Vector2 moveDirection;
    private bool isMagnetized = false;
    private Player _player;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Player player) {
        _player = player;
        _player.OnMagnetPickUp += MagnetEffect;
    }
    private void OnDisable() {
        _player.OnMagnetPickUp -= MagnetEffect;
    }

    private void MagnetEffect()
    {
        if (pickupType == PickupType.Expperience)
        {
            isMagnetized = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<Player>();
        if (player)
        {
            DetectPickupType(player);
            Destroy(gameObject);
        }
    }

    private void Update() {
        Vector3 playerPos = _player.transform.position;

        if (Vector2.Distance(transform.position, playerPos) < magnetDistance || isMagnetized) {
            isMagnetized = true;
            moveDirection = (playerPos - transform.position).normalized;
            moveSpeed += acceleration;
        }
    }
    
    private void FixedUpdate() {
        _rb.linearVelocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    private void DetectPickupType(Player player)
    {
        switch (pickupType)
        {
            case PickupType.Expperience:
                player.OnExpPickUp?.Invoke(_expAmount);
                break;

            case PickupType.Health:
                player.OnHealthPickUp?.Invoke(_healAmount);
                break;
            
            case PickupType.Magnet:
                player.OnMagnetPickUp?.Invoke();
                break;

            default:
                Debug.Log("Что-то пошло не так?");
                break;
        }
    }
}
