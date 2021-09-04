using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    private float iFrames;

    void Start()
    {
        
    }

    void Update()
    {
        iFrames -= Time.deltaTime;
    }

    public void TakeDamage(float hpLost)
    {
        if (iFrames <= 0)
        {
            health -= hpLost;
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                if (gameObject.CompareTag("Player"))
                {
                    iFrames = .8f;
                }
            }
        }
    }
}
