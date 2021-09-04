using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        switch(layerName) {
            case "Ammo":
                gameController.AddAmmo(200);
                break;
        }
    }
}
