using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public int maxHealthPoints;
    public float moveSpeed;
    public GameObject weapon;
    
}
