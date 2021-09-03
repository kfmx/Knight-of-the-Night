using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    private float time = 1;

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(gameObject);
        }
    }
}
