public class DamageInc : BasePerk
{
    
    public override void ApplyEffect(IPerkTarget target)
    {
        var weapon = (target as Player)?.GetComponentInChildren<ActiveWeapon>()?.GetCurrentWeapon();
        weapon.IncreaseDamage(1);
    }

    public override void RemoveEffect(IPerkTarget target)
    {
        throw new System.NotImplementedException();
    }
}

