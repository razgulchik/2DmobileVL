using System.Collections;
using UnityEngine;

public class Shootgun : MonoBehaviour, IWeapon
{
    public WeaponInfo Info => weaponInfo;
    
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _bulletCount = 5;

    public float _currWeaponDamage;
    public float _currWeaponRange;
    public float _currWeaponCooldown;
    public float _currBulletSpeed;
    public GameObject _currBulletPrefab; 

    private bool isAttacking = false;

    private PoolMono<Bullet> _bulletPool;

    private void Initialize() {
        _currWeaponDamage = weaponInfo.weaponDamage;
        _currWeaponRange = weaponInfo.weaponRange;
        _currWeaponCooldown = weaponInfo.weaponCooldown;
        _currBulletSpeed = weaponInfo.bulletSpeed;
        _currBulletPrefab = weaponInfo.bulletPrefab; 
    }

    private void Start() {
        Initialize();
        _bulletPool = new PoolMono<Bullet>(_currBulletPrefab.GetComponent<Bullet>(), _bulletCount, null);
    }

    public void Attack() {
        if (isAttacking) return;
        
        isAttacking = true;
        Shot();
        
        StopAllCoroutines();
        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine() {
        yield return new WaitForSeconds(_currWeaponCooldown);
        isAttacking = false;
    }

    private void Shot() {
        var newBullet = _bulletPool.Get();
        newBullet.transform.position = _spawnPoint.position;
        newBullet.transform.rotation = _spawnPoint.rotation;
        newBullet.GetComponent<DamageSource>().Init(_currWeaponDamage);
        newBullet.GetComponent<Rigidbody2D>().linearVelocity = transform.right * _currBulletSpeed;
    }

    public void IncreaseDamage(float value) {
        _currWeaponDamage += Mathf.Clamp(value, 0, 10);
    }

    public void IncreaseFireRate(float value) {
        float reduction = weaponInfo.weaponCooldown * value;
        _currWeaponCooldown = Mathf.Max(_currWeaponCooldown - reduction, 0f);
    }

    public void IncreaseBulletSpeed(float value) {
        float increment = weaponInfo.bulletSpeed * value;
        _currBulletSpeed = Mathf.Clamp(_currBulletSpeed + increment, 0f, 50f);
    }
}
