using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerCollisions collision;

    [Header("Player class (overview)")]
    [SerializeField] private Player player;

    public void SetCharacter(Player newPlayer)
    {
        player = newPlayer;

        if (player == null)
        {
            Debug.LogError("PlayerCharacter: no player!");
        }

        controller.SetController(player);
        collision.SetCollisions(player);
    }

    public void StartCharacter()
    {
        controller.PauseUpdate = false;
        GetComponent<PolygonCollider2D>().enabled = true;
        gameObject.SetActive(true);
    }

    public void StopCharacter()
    {
        controller.PauseUpdate = true;
        GetComponent<PolygonCollider2D>().enabled = false;
        gameObject.SetActive(false);
    }

}
