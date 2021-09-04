using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameController gameController;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameController.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<HealthPickup>() && gameController.curHealth < gameController.getMaxHealth())
        {
            HealthPickup healthPickup = other.gameObject.GetComponent<HealthPickup>();
            gameController.AddHealth(healthPickup.health);
            Destroy(healthPickup.gameObject);
            Debug.Log(gameController.curHealth);
        }
    }

    public void TakeDamage(int dmg)
    {
        gameController.RemoveHealth(dmg);
    }
}
