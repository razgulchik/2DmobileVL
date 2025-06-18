using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveInfo[] _waves;
    [SerializeField] private float _waveLenght = 60f;
    [SerializeField] private float _delayBetweenSpawns = 2f;

    private Transform _player;
    private int _currentWaveIndex = 0;

    //Camera data
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

    public void Initialization(Transform player) {
        _player = player;
    }

    public IEnumerator SpawnWavesRoutine() {
        foreach (var wave in _waves)
        {
            _currentWaveIndex++;
            Debug.Log($"Текущая волна {_currentWaveIndex}");

            List<GameObject> enemiesToSpawn = new List<GameObject>();

            foreach (var group in wave.enemyGroups)
            {
                for (int i = 0; i < group.count; i++)
                {
                    enemiesToSpawn.Add(group.enemyPrefab);
                }
            }

            ShuffleEnimies(enemiesToSpawn);

            StartCoroutine(SpawnEnemyGroupRoutine(enemiesToSpawn));
            
            yield return new WaitForSeconds(_waveLenght);
        }
    }

    private IEnumerator SpawnEnemyGroupRoutine(List<GameObject> enemiesToSpawn)
    {
        foreach (var enemy in enemiesToSpawn)
        {
            SpawnEnemies(enemy);
            yield return new WaitForSeconds(_delayBetweenSpawns);
        }
    }

    private void ShuffleEnimies<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    
    private void SpawnEnemies(GameObject enemyPrefab)
    {
        Vector2 randomPosInCircle = Random.insideUnitCircle * 10;
        Vector3 offset = new Vector3(ExcludeRange(randomPosInCircle.x, -_camWidth , _camWidth), 
                                    ExcludeRange(randomPosInCircle.y, -_camHeight, _camHeight), 
                                    _player.position.z);
        Vector3 randomPos = _player.position + offset;
        Vector3 clampedRandomPos = new Vector3(Mathf.Clamp(randomPos.x, _minBorder, _maxBorder), 
                                        Mathf.Clamp(randomPos.y, _minBorder, _maxBorder), 
                                        _player.position.z);
        
        GameObject newEnemyObject = Instantiate(enemyPrefab, clampedRandomPos, Quaternion.identity);
        Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();
        newEnemy.Init(_player.gameObject.GetComponent<Player>());
    }

    private float ExcludeRange(float value, float min, float max) {
        if (value > min && value < max)
        {
            return (value - min < max - value) ? min : max;
        }
        return value;
    }
}
