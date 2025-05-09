using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Objects/NewWeapon")]
public class WeaponInfo : ScriptableObject
{
    public int weaponDamage;
    public float weaponRange;
    public float weaponCooldown;
    public float bulletSpeed;
    public GameObject bulletPrefab;
}
