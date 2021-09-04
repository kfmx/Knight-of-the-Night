using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firingPoint;
    [SerializeField]
    private GameController gameController;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameController.curAmmo > 0) {
            Instantiate(bullet, firingPoint.position, transform.rotation, transform);
            gameController.curAmmo--;
        }
    }
}
