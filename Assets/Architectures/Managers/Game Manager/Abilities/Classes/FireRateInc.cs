using UnityEngine;

public class FireRateInc : BasePerk
{
    
    public override void ApplyEffect(IPerkTarget target)
    {
        LevelUp();
        if (Info == null) { Debug.Log("Info not initialized"); return; }
        
        var weapon = (target as Player)?.GetComponentInChildren<ActiveWeapon>()?.GetCurrentWeapon();
        weapon.IncreaseFireRate(Info.value);
    }

    public override void RemoveEffect(IPerkTarget target)
    {
        throw new System.NotImplementedException();
    }
}

