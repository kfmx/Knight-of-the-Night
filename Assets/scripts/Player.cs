using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private BoxCollider2D cl2;
    private PlayerHealth hp;

    void Start()
    {
        cl2 = GetComponent<BoxCollider2D>();
        hp = GetComponent<PlayerHealth>();
        Instance = this;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float DamageTaken)
    {
        hp.TakeDamage((int)DamageTaken);
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
