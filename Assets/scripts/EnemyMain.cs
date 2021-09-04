using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Rigidbody2D mine;
    private Health hp;

    private void Start()
    {
        hp = GetComponent<Health>();
    }

    public void TakeDamage(float dmg)
    {
        hp.TakeDamage(dmg);
    }
}
