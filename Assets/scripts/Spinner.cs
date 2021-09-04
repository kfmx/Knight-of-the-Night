using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 0.1f;
    [SerializeField]
    private float maxSpeed = 3;
    private float rotationSpeed;

    void Start()
    {
        int sign = Random.Range(0, 2) * 2 - 1;  //-1 or 1
        rotationSpeed = Random.Range(minSpeed, maxSpeed) * sign;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed, Space.World);
    }
}
