using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Header("Объект игрока")]
    [SerializeField] private Transform _player;
    [Header("Параметры камеры")]
    [SerializeField] private float _returnSpeed = 10;

    private Vector3 _playerPosition;
    
    private void Update() {
        FollowPlayer();
    }

    public void SetOnPlayer(Transform playerPosition) {
        _player = playerPosition;
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        transform.rotation = Quaternion.identity;
    }

    private void FollowPlayer() {
        _playerPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _playerPosition, _returnSpeed * Time.deltaTime);
    }
}
