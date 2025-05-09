using UnityEngine;
using UnityEngine.UI;

public class ExperienceUI : MonoBehaviour
{
    private ExperienceManager _expManager;
    private Slider _slider;

    public void Init(ExperienceManager expManager) {
        _expManager = expManager;
        _expManager.OnExpChanged += UpdateExpSlider;
        _expManager.OnRequiredExpChanged += UpdateMaxExp;
    }

    private void OnDisable() {
        _expManager.OnExpChanged -= UpdateExpSlider;
        _expManager.OnRequiredExpChanged -= UpdateMaxExp;
    }

    private void Awake() {
        _slider = GetComponent<Slider>();
    }

    private void UpdateExpSlider(int value) {
        _slider.value = value;
    }

    private void UpdateMaxExp(int value) {
        _slider.maxValue = value;
    }


}
