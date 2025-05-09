using UnityEngine;

public class MainCharacterSpawner : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerPrefab;

    public PlayerHealth SpawnPlayer() 
    {
        var player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        
        return player;
    }
}
