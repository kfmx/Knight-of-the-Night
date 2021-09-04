using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    private float time = 1;
    [SerializeField]
    private bool useCollision = false;
    [SerializeField]
    private LayerMask onCollisionWith;

    void Update()
    {
        if (!useCollision) {
            time -= Time.deltaTime;
            if (time <= 0) {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (onCollisionWith == (onCollisionWith | (1 << collision.gameObject.layer))) {
            Destroy(gameObject);
        }
    }
}
