using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelath : MonoBehaviour
{
    public float hp = 100;

    public void TakeDamage(float dmg)
    {
        if (hp > 0)
        {
            hp -= dmg;
        } else
        {
            Destroy(gameObject);
        }
    }
}
