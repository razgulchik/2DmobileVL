using System;
using UnityEngine;

public class Player : MonoBehaviour, IPerkTarget
{
    [SerializeField] private PlayerInfo _playerConfig;

    public GameObject Weapon => _playerConfig.weapon;
    public int MaxHP => _playerConfig.maxHealthPoints;
    public float MoveSpeed => _playerConfig.moveSpeed;
    
    public Action<int> OnExpPickUp;
    public Action<int> OnHealthPickUp;
    public Action OnMagnetPickUp;

}
