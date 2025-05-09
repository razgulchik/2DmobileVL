using UnityEngine;

[RequireComponent(typeof(EnemyAI))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyInfo _enemyInfo;

    public int HealthPoints { get; private set; }
    public float MoveSpeed { get; private set; }
    public Player Player { get; set; }

    private void Awake() {
        HealthPoints = _enemyInfo.healthPoints;
        MoveSpeed = _enemyInfo.moveSpeed;
    }

    public void Init(Player player) {
        Player = player;
    }
}