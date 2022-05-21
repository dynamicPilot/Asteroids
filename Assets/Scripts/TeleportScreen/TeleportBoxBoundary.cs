using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TeleportBoxBoundary : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private TeleportBox teleportBox;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        teleportBox = new TeleportBox(boxCollider.size);
    }

    private void OnTriggerExit2D (Collider2D collider)
    {
        teleportBox.HaveOnCollisionExit(collider);
    }
}
