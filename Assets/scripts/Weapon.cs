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
    private int maxAmmo = 20;
    private int curAmmo = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && curAmmo > 0) {
            Instantiate(bullet, firingPoint.position, transform.rotation, transform);
            curAmmo--;
        }
    }
}
