using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private Slider _healthSlider;

    public void Init(PlayerHealth playerHealth) {
        _healthSlider = GetComponent<Slider>();
        _playerHealth = playerHealth;
        _playerHealth.OnPlayerHealthChanged += UpdateHealthSlider;
        _playerHealth.OnMaxHPChanged += SetMaxHP;
    }

    private void OnDisable() {
        _playerHealth.OnPlayerHealthChanged -= UpdateHealthSlider;
        _playerHealth.OnMaxHPChanged -= SetMaxHP;
    }

    private void UpdateHealthSlider(int currentHealth) {
        _healthSlider.value = currentHealth;
    }

    private void SetMaxHP(int newMaxHP) {
        _healthSlider.maxValue = newMaxHP;
    }

}
