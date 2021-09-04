using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    private float time = 1;
    [SerializeField]
    private bool onCollision = false;
    private BoxCollider2D cl2;

    private void Start()
    {
        cl2 = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckForCollision();
        if (!onCollision) {
            time -= Time.deltaTime;
            if (time <= 0) {
                Destroy(gameObject);
            }
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
