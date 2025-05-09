using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    private ExperienceManager _expManager;
    private TMP_Text _levelCount;

    public void Init(ExperienceManager expManager) {
        _expManager = expManager;
        _expManager.OnLevelUp += UpdateExpSlider;
    }

    private void OnDisable() {
        _expManager.OnLevelUp -= UpdateExpSlider;
    }

    private void Awake() {
        _levelCount = GetComponent<TMP_Text>();
    }

    private void UpdateExpSlider(int value) {
        _levelCount.text = value.ToString();
    }
}
