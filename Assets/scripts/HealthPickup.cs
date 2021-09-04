using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float iFrames;

    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
