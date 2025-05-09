using UnityEngine;

[RequireComponent(typeof(TargetDetection))]
public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;

    private IWeapon _currentWeapon;
    private Transform _enemy;

    private void Awake() {
        _weaponPrefab = GetComponentInParent<Player>().Weapon;
    }

    private void Start()
    {
        EquipWeapon(_weaponPrefab);
    }

    private void EquipWeapon(GameObject weaponPrefab)
    {
        var currentWeapon = Instantiate(weaponPrefab, transform.position, transform.rotation);
        currentWeapon.transform.parent = transform;
        _currentWeapon = currentWeapon.GetComponent<IWeapon>();
    }

    private void Update() {
        AimingAtEnemy();
    }

    private void AimingAtEnemy() {
        if (_enemy == null) { return; }

        Vector2 lookDirection = _enemy.position - transform.position;

        float angle = Mathf.Atan2(lookDirection.y, Mathf.Abs(lookDirection.x)) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -80, 80);

        if (lookDirection.x < 0) {
            transform.rotation = Quaternion.Euler(0, -180, angle);
        } else if (lookDirection.x > 0) {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        AutoShoot();
     }

    private void AutoShoot()
    {
        var enemyCollider = _enemy.GetComponent<CapsuleCollider2D>();
        if (_currentWeapon == null || !enemyCollider.isActiveAndEnabled) { return; }
        _currentWeapon.Attack();
    }

    public void SetTarget(Transform enemy) {
        _enemy = enemy;
    }

    public IWeapon GetCurrentWeapon() {
        return _currentWeapon;
    }
}