using UnityEngine;

public class MoveSpeedInc : BasePerk
{
    public override void ApplyEffect(IPerkTarget target)
    {
        LevelUp();
        if (Info == null) { Debug.Log("Info not initialized"); return; }

        var playerController = (target as Player)?.GetComponentInChildren<PlayerController>();
        playerController.IncreaseSpeed(Info.value);
    }

    public override void RemoveEffect(IPerkTarget target)
    {
        throw new System.NotImplementedException();
    }
}
