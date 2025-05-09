using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 3f;

    private CircleCollider2D _detectionCollider;
    private HashSet<Enemy> _detectedEnemies = new HashSet<Enemy>();
    private ActiveWeapon _myActiveWeapon;

    private void Awake() {
        _detectionCollider = GetComponent<CircleCollider2D>();
        _myActiveWeapon = GetComponent<ActiveWeapon>();
    }

    private void Start() {
        _detectionCollider.radius = _detectionRadius;
    }

    private void Update() {
        FindClosestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Enemy>())
        {
            _detectedEnemies.Add(other.GetComponent<Enemy>());
            other.GetComponent<EnemyHealth>().OnEnemyDied += HandleEnemyDied;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Enemy>())
        {
            _detectedEnemies.Remove(other.GetComponent<Enemy>());
            other.GetComponent<EnemyHealth>().OnEnemyDied -= HandleEnemyDied;
        }
    }

    private void FindClosestEnemy() {
        float minDistance = Mathf.Infinity;
        if (_detectedEnemies.Count != 0)
        {
            foreach (Enemy enemy in _detectedEnemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _myActiveWeapon.SetTarget(enemy.transform);
                }
            }
        } 
    }

    private void HandleEnemyDied(EnemyHealth enemyHealth) {
        enemyHealth.OnEnemyDied -= HandleEnemyDied;
        Enemy enemy = enemyHealth.GetComponent<Enemy>();
        _detectedEnemies.Remove(enemy);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
