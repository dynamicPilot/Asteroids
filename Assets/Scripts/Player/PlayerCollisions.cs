using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollisions : MonoBehaviour
{
    private Player player;

    public void SetCollisions(Player newPlayer)
    {
        player = newPlayer;

        if (player == null)
        {
            Debug.LogError("PlayerController: no player!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("UFO"))
        {
            player.PlayerHasDied();
        }
    }
}
