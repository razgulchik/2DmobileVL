using UnityEngine;

[CreateAssetMenu(fileName = "WaveInfo", menuName = "Scriptable Objects/WaveInfo")]
public class WaveInfo : ScriptableObject
{
    [System.Serializable]
    public struct EnemyGroup
    {
        public GameObject enemyPrefab;
        public int count;
    }
    
    public EnemyGroup[] enemyGroups;
}
