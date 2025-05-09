using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private PlayerHealth _player;

    public GameManager (PlayerHealth player) {
        _player = player;
        _player.OnPlayerDeath += RestartGame;
    }

    private void RestartGame()
    {
        _player.OnPlayerDeath -= RestartGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
