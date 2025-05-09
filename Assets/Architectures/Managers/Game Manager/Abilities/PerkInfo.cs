using UnityEngine;

[CreateAssetMenu(fileName = "PerkInfo", menuName = "Perks/PerkInfo")]
public class PerkInfo : ScriptableObject
{
    [Header("Визуальные параметры")]
    public Sprite image;
    public string header;
    [TextArea] public string description;
    [Header("Параметры изменения")]
    public float value;
    public int level;
    [Header("Префаб перка")]
    public BasePerk perk;
}
