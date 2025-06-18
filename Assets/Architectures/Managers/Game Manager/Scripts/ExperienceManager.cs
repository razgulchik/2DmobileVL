using System;

public class ExperienceManager
{
    private Player _player;
    private int _expPoints;
    private int _currentLevel;
    private int _requiredExpToLevelUp;

    public Action<int> OnExpChanged;
    public Action<int> OnLevelUp;
    public Action<int> OnRequiredExpChanged;

    public ExperienceManager (PlayerHealth player) {
        _player = player.GetComponent<Player>();
        _player.OnExpPickUp += AddExp;
        _expPoints = 0;
        _currentLevel = 0;
        _requiredExpToLevelUp = 2;
    }

    private void AddExp(int value) {
        _expPoints += value;
        OnExpChanged?.Invoke(_expPoints);
        CheckLevel(_expPoints);
    }

    private void OnDisable() {
        _player.OnExpPickUp -= AddExp;
    }

    private void CheckLevel(int value) {
        if (value >= _requiredExpToLevelUp)
        {
            _expPoints = 0;
            OnExpChanged?.Invoke(_expPoints);
            LevelUp();
        }
    }

    private void LevelUp() {
        _currentLevel += 1;
        OnLevelUp?.Invoke(_currentLevel);
        _requiredExpToLevelUp += 3;
        OnRequiredExpChanged?.Invoke(_requiredExpToLevelUp);
    }
}
