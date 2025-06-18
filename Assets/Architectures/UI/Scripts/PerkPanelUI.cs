using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerkPanelUI : MonoBehaviour
{
    [SerializeField] private List<PerkSlotUI> _listOfSlots;
    [SerializeField] private List<PerkInfo> _listOfAbilities;
    private ExperienceManager _expManager;
    private Player _player;

    public void Init(ExperienceManager expManager, Player player) {
        _player = player;
        _expManager = expManager;
        gameObject.SetActive(false);
        _expManager.OnLevelUp += OpenLevelUpPanel;
        ResetAllLevels();
    }

    private void OnDestroy() {
        _expManager.OnLevelUp -= OpenLevelUpPanel;
    }

    private void OpenLevelUpPanel(int value)
    {
        SetRandomAbilities();
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChooseAbility(PerkSlotUI perk) {
        perk.GetPerk()?.ApplyEffect(_player);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void SetRandomAbilities()
    {
        var tempList = new List<PerkInfo>(_listOfAbilities);
        for (int i = 0; i < _listOfSlots.Count; i++)
        {
            var newAbility = GetRandomAbility(tempList);
            _listOfSlots[i].SetAbility(newAbility);
            tempList.Remove(newAbility);
        }
    }

    private PerkInfo GetRandomAbility(List<PerkInfo> listOfAbilities) {
        return listOfAbilities[Random.Range(0, listOfAbilities.Count)];
    }

    private void ResetAllLevels() {
        foreach (var item in _listOfAbilities)
        {
            item.perk.ResetLevel();
        }
    }
    
}
