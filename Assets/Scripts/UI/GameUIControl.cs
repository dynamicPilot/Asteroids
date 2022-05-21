using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIControl : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Text coordinatesText; // player coordinates
    [SerializeField] private Text shipAngleText;
    [SerializeField] private Text shipSpeedText;
    [SerializeField] private Text laserShootsRemainText;
    [SerializeField] private LaserRecoveryUI laserRecoveryUI;
    [SerializeField] private Text scoreText;

    [Header("Start Panel")]
    [SerializeField] private GameObject startPanel;

    [Header("GameOver UI Components")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text finalScoreText;

    private Player player;

    private bool pauseUpdate = true;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void SetUI(Player _player)
    {
        player = _player;
    }
    public void StartGame()
    {
        laserRecoveryUI.SetBar();
        pauseUpdate = false;
    }

    public void StopGame()
    {
        pauseUpdate = true;
        finalScoreText.text = String.Format("score {0:D4}", player.Score);
        gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (pauseUpdate) return;

        UpdateUI();
    }

    private void UpdateUI()
    {
        coordinatesText.text = String.Format("( {0:F1} ; {1:F1})", player.GetPosition().x, player.GetPosition().y);
        shipAngleText.text = String.Format("{0:F0}°", player.GetAngle());
        shipSpeedText.text = String.Format("{0:F1} */s", player.PlayerBody.GetVelocity());

        laserShootsRemainText.text = String.Format("{0}", player.PlayerShooting.LaserShoots);

        // update laser bar
        if (player.PlayerShooting.IsRecovering || !laserRecoveryUI.IsFull)
        {
            laserRecoveryUI.UpdateBar(player.PlayerShooting.RecoveringProgress);
        }

        scoreText.text = String.Format("{0:D4}", player.Score);
    }
}
