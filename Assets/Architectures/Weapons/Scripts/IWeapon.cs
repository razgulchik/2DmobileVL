public interface IWeapon 
{
    public WeaponInfo Info { get; }
    public void Attack();
    public void IncreaseDamage(float value);
    public void IncreaseFireRate(float value);
    public void IncreaseBulletSpeed(float value);
}