using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>GameControl</c> keeps main references to scene components, starts game and creates gameManager.
/// </summary>
/// 
public class GameControl : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameUIControl gameUIControl;

    private GameManager gameManager;
    private void Awake()
    {
        gameManager = new GameManager(this, playerTransform);

        if (gameManager == null)
        {
            Debug.LogError("GameControl: no gameManager!");
        }

        gameUIControl.SetUI(gameManager.ActivePlayer);
    }

    public void StartGame()
    {
        gameManager.StartGame();
        gameUIControl.StartGame();
    }

    public void StopGame()
    {
        gameUIControl.StopGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
