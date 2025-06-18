using System.ComponentModel;
using UnityEngine;

public class DamageInc : BasePerk
{
    public override void ApplyEffect(IPerkTarget target)
    {
        LevelUp();
        if (Info == null) { Debug.Log("Info not initialized"); return; }

        var weapon = (target as Player)?.GetComponentInChildren<ActiveWeapon>()?.GetCurrentWeapon();
        weapon.IncreaseDamage(Info.value);
    }

    public override void RemoveEffect(IPerkTarget target)
    {
        throw new System.NotImplementedException();
    }
}

