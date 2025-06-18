using UnityEngine;

public class MaxHPInc : BasePerk
{
    public override void ApplyEffect(IPerkTarget target)
    {
        LevelUp();
        if (Info == null) { Debug.Log("Info not initialized"); return; }

        var playerHealth = (target as Player)?.GetComponentInChildren<PlayerHealth>();
        playerHealth.IncreaseMaxHP(Info.value);
    }

    public override void RemoveEffect(IPerkTarget target)
    {
        throw new System.NotImplementedException();
    }
}
