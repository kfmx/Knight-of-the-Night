using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        move();
        rotateToMouse();
    }


    void rotateToMouse()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = transform.position;

        Vector2 Point_1 = new Vector2(playerPosition.x, playerPosition.y);
        Vector2 Point_2 = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x) * 180 / Mathf.PI;

        rigidbody.SetRotation(angle - 90);
    }

    void move()
    {
        
        if (Input.GetKey("a"))
        {
            float angle = Mathf.PI;
            rigidbody.AddForce(new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed));
        }
        if (Input.GetKey("d"))
        {
            float angle = 0;
            rigidbody.AddForce(new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed));
        }
        if (Input.GetKey("w"))
        {
            float angle = Mathf.PI / 2;
            rigidbody.AddForce(new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed));
        }
        if (Input.GetKey("s"))
        {
            float angle = -Mathf.PI / 2;
            rigidbody.AddForce(new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed));
        }
    }
}