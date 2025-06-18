using UnityEngine;

public abstract class BasePerk : MonoBehaviour
{
    public PerkInfo Info { get; protected set; }
    public int Level { get; protected set; }

    public virtual void Initialize(PerkInfo info) {
        Info = info;
    }

    public virtual void ResetLevel() {
        Level = 1;
    }

    protected void LevelUp() {
        Level += 1;
    }

    public abstract void ApplyEffect(IPerkTarget target);
    public abstract void RemoveEffect(IPerkTarget target);

}
