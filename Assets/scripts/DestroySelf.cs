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
    private bool onCollision = false;
    private BoxCollider2D cl2;

    private void Start()
    {
        cl2 = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckForCollision();
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

    private void CheckForCollision()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (cl2.IsTouching(enemy.GetComponent<BoxCollider2D>()))
            {
                enemy.GetComponent<EnemyMain>().TakeDamage(20);
                Destroy(gameObject);
            }
        }
    }
}
