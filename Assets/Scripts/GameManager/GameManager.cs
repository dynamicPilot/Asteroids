using UnityEngine;

public class GameManager
{
    Player player;
    public Player ActivePlayer { get => player; }
    GameControl gameControl;
    EnemyCreator enemyCreator;

    public GameManager (GameControl _gameControl, Transform playerTransform)
    {
        Time.timeScale = 1f;
        gameControl = _gameControl;
        player = new Player();
        enemyCreator = new EnemyCreator(player, gameControl.GetComponent<EnemySpawnerTimerAndCreator>());

        player.OnPlayerHasDied += GameOver;

        player.SetPlayer(playerTransform);
    }

    public void StartGame()
    {
        enemyCreator.StartEnemyCreator();
        player.StartPlayer();
    }

    public void GameOver()
    {
        player.OnPlayerHasDied -= GameOver;
        gameControl.StopGame();
        enemyCreator.StopEnemyCreator();
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        gameControl.RestartGame();
    }
}
