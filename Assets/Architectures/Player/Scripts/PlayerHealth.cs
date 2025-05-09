using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;

    private bool _isDead = false;
    private bool _canTakeDamage = true;

    private Animator _myAnimator;
    private Flash _flash;

    public Action<int> OnPlayerHealthChanged;
    public Action<int> OnMaxHPChanged;
    public Action OnPlayerDeath;

    readonly int DEAD_HASH = Animator.StringToHash("Dead");

    private void OnEnable() {
        GetComponent<Player>().OnHealthPickUp += AddHP;
    }
    private void OnDisable() {
        GetComponent<Player>().OnHealthPickUp -= AddHP;
    }

    private void Awake() {
        _maxHP = GetComponentInParent<Player>().MaxHP;
        _myAnimator = GetComponent<Animator>();
        _flash = GetComponent<Flash>();
    }

    private void Start() {
        UpdateMaxHP(_maxHP);
        _currentHP = _maxHP;
    }

    public void TakeDamage(int damageAmount) {
        if (_isDead || !_canTakeDamage) { return; }
        
        _canTakeDamage = false;
        StartCoroutine(_flash.FlashRoutine());
        _currentHP -= damageAmount;
        OnPlayerHealthChanged?.Invoke(_currentHP);
        StartCoroutine(RecoveryAfterHitRoutine());

        DetectDeath();
    }

    private void DetectDeath() {
        if (_currentHP <= 0)
        {
            _isDead = true;
            _myAnimator.SetTrigger(DEAD_HASH);
            OnPlayerDeath.Invoke();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(1);
        }
    }

    private IEnumerator RecoveryAfterHitRoutine() {
        yield return new WaitForSeconds(1f);
        _canTakeDamage = true;
    }

    private void UpdateMaxHP(int newMaxHP) {
        _maxHP = newMaxHP;
        OnMaxHPChanged.Invoke(_maxHP);
    }

    private void AddHP (int value) {
        _currentHP = Mathf.Clamp(_currentHP + value, 0, _maxHP);
        OnPlayerHealthChanged?.Invoke(_currentHP);
    }
}
