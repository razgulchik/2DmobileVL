using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkSlotUI : MonoBehaviour
{
    [SerializeField] private PerkInfo _perkInfo;
    [SerializeField] private Image _imageConteiner;
    [SerializeField] private TMP_Text _headerContainer;
    [SerializeField] private TMP_Text _descrContainer;
    //[SerializeField] private float _value;
    [SerializeField] private TMP_Text _levelContainer;
    
    public void SetAbility(PerkInfo perkInfo) {
        _perkInfo = perkInfo;
        _perkInfo.perk.Initialize(perkInfo);
        _imageConteiner.sprite = perkInfo.image;
        _headerContainer.text = perkInfo.header;
        _descrContainer.text = perkInfo.description;
        //_value = perkInfo.value;
        _levelContainer.text = perkInfo.perk.Level.ToString();
    }

    public BasePerk GetPerk() {
        return _perkInfo.perk;
    }
}
