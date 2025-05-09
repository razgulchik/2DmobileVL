using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount = 10;
    [SerializeField] private float _delayBetweenSpawns = 2f;

    private float _minBorder = -19f;
    private float _maxBorder = 19f;
    private Camera _camera;
    private float _camHeight;
    private float _camWidth;

    private void Start() {
        _camera = Camera.main;
        _camHeight = _camera.orthographicSize;
        _camWidth = _camHeight * _camera.aspect;
    }

    public IEnumerator SpawnEnemies(Transform playerPos) {
        for (int i = 0; i < _enemyCount; i++)
        {
            Vector2 randomPosInCircle = Random.insideUnitCircle * 10;
            Vector3 offset = new Vector3(ExcludeRange(randomPosInCircle.x, -_camWidth , _camWidth), 
                                        ExcludeRange(randomPosInCircle.y, -_camHeight, _camHeight), 
                                        playerPos.position.z);
            Vector3 randomPos = playerPos.position + offset;
            Vector3 clampedRandomPos = new Vector3(Mathf.Clamp(randomPos.x, _minBorder, _maxBorder), 
                                            Mathf.Clamp(randomPos.y, _minBorder, _maxBorder), 
                                            playerPos.position.z);
            
            Enemy enemy = Instantiate(_enemyPrefab, clampedRandomPos, Quaternion.identity);
            enemy.Init(playerPos.gameObject.GetComponent<Player>());
            
            yield return new WaitForSeconds(_delayBetweenSpawns);
        }
    }

    private float ExcludeRange(float value, float min, float max) {
        if (value > min && value < max)
        {
            return (value - min < max - value) ? min : max;
        }
        return value;
    } 
}
