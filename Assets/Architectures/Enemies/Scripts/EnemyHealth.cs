using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    private Enemy _enemyComponent;
    private Player _player;
    private int _healthPoints;
    private float _currentHP;
    private bool _isDead = false;
    private Animator _myAnimator;
    private PickupSpawner _pickupSpawner;

    readonly int HIT_HASH = Animator.StringToHash("Hit");
    readonly int DEAD_HASH = Animator.StringToHash("Dead");

    public Action<EnemyHealth> OnEnemyDied;

    private void Awake() {
        _enemyComponent = GetComponent<Enemy>();
        _myAnimator = GetComponent<Animator>();
        _pickupSpawner = GetComponent<PickupSpawner>();
        _healthPoints = _enemyComponent.HealthPoints;
    }

    private void Start() {
        _player = _enemyComponent.Player;
        Resurrect();
    }

    public void TakeDamage(float damageAmount) {
        if (_isDead) { return; }
        
        _currentHP -= damageAmount;
        _myAnimator.SetTrigger(HIT_HASH);

        DetectDeath();
    }

    private void DetectDeath() {
        if (_currentHP <= 0)
        {
            _isDead = true;
            _myAnimator.SetTrigger(DEAD_HASH);
            OnEnemyDied?.Invoke(this);
            _pickupSpawner.DropItem(_player);
        }
    }

    private void Resurrect() {
        _currentHP = _healthPoints;
        _isDead = false;
    }

    public void DestroyAfterDeathEvent() {
        Destroy(gameObject);
    }
}
