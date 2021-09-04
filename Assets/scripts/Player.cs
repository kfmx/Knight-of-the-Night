using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private BoxCollider2D cl2;
    private Health hp;

    void Start()
    {
        cl2 = GetComponent<BoxCollider2D>();
        hp = GetComponent<Health>();
        Instance = this;
    }

    public void TakeDamage(float DamageTaken)
    {
        hp.TakeDamage(DamageTaken);
    }

    public BoxCollider2D GetCollider()
    {
        return cl2;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
