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
    }

    public void TakeDamage(float dmg)
    {
        hp.TakeDamage(dmg);
    }
}
