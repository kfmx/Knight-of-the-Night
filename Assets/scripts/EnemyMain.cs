using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Rigidbody2D mine;
    private EnemyHelath hp;

    private void Start()
    {
        hp = GetComponent<EnemyHelath>();
        gameObject.transform.position = new Vector3(Random.Range(-200, 200), Random.Range(-200, 200));
    }

    public void TakeDamage(float dmg)
    {
        hp.TakeDamage(dmg);
    }
}
