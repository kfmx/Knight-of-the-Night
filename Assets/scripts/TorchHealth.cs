using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHealth : MonoBehaviour
{

    private int health = 50;
    private float iFrames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iFrames -= Time.deltaTime;
    }

    public void TakeDamage(int dmg)
    {
        if (iFrames <= 0)
        {
            health -= dmg;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            iFrames = 0.3f;
        }
    }
}
