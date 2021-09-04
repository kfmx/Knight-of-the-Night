using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;

    void LateUpdate() {
        transform.position = new Vector3(player.position.x, player.position.y, -10); // Camera follows the player with specified offset position
    }
}
