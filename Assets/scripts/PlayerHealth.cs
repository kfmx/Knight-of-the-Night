using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50;
    public float maxHealth = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.GetComponent<HealthPickup>())
        {
            HealthPickup healthPickup = other.gameObject.GetComponent<HealthPickup>();
            setHealth(health + healthPickup.health);
            Destroy(healthPickup.gameObject);
            Debug.Log(health);
        }
    }

    void takeDamage(float damage)
    {
        setHealth(health - damage);
    }

    void setHealth(float health)
    {
        this.health = Mathf.Min(Mathf.Max(health, 0), maxHealth);
    }

}
