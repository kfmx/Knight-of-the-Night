using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player Instance { get; private set; }
    float hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float dmg)
    {
        hp -= dmg;
            
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
