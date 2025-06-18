using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainCharacterSpawner _mainCharacterSpawner;
    [SerializeField] private FollowingCamera _followingCamera;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private ExperienceUI _experienceUI;
    [SerializeField] private LevelUI _levelUI;
    [SerializeField] private PerkPanelUI _abilityPanelController;
    [SerializeField] private WaveManager _waveManager;

    private void Awake()
    {
        PlayerHealth player = _mainCharacterSpawner.SpawnPlayer();
        _followingCamera.SetOnPlayer(player.transform);
        _healthUI.Init(player);
        GameManager gameManager = new GameManager(player);
        ExperienceManager experienceManager = new ExperienceManager(player);
        _experienceUI.Init(experienceManager);
        _levelUI.Init(experienceManager);
        _abilityPanelController.Init(experienceManager, player.GetComponent<Player>());

        //Spawn enemies
        _waveManager.Initialization(player.transform);
        StartCoroutine(_waveManager.SpawnWavesRoutine());
    }
}
