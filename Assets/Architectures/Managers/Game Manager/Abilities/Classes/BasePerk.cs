using UnityEngine;

public abstract class BasePerk : MonoBehaviour
{
    public PerkInfo Info { get; protected set; }

    public virtual void Initialize(PerkInfo info) {
        Info = info;
    }

    public abstract void ApplyEffect(IPerkTarget player);
    public abstract void RemoveEffect(IPerkTarget player);
}
