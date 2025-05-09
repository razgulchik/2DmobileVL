using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyMover))]

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Chase,
        Die
    }

    private EnemyMover _enemyMover;
    private EnemyHealth _enemyHealth;
    private State _state;
    private Player _player;

    private void Awake() {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _state = State.Chase;
    }

    private void Start() {
        _enemyHealth.OnEnemyDied += HandleEnemyDied;
        _player = GetComponent<Enemy>().Player;
    }

    private void Update() {
        StateControll();
    }

    private void StateControll() {
        switch (_state)
        {
            default:
            case State.Chase:
                Chasing();
            break;

            case State.Die:
                DoNothing();
            break;
        }
    }

    private void Chasing() {
        if (!_player) { return; }
        Vector3 playerPosition = _player.gameObject.transform.position;
        Vector3 movemenDirection = (playerPosition - transform.position).normalized;
        _enemyMover.MoveTo(movemenDirection);
    }

    private void HandleEnemyDied(EnemyHealth enemyHealth) {
        _enemyHealth.OnEnemyDied -= HandleEnemyDied;
        _state = State.Die;
    }

    private void DoNothing() {
        _enemyMover.MoveTo(Vector2.zero);
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
