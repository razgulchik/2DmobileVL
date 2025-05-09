public interface IWeapon 
{
    public WeaponInfo Info { get; }
    public void Attack();
    public void IncreaseDamage(int value);
}