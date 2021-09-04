using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private enum State
    {
        ChasePlayer,
        DestroyLight
    }

    private EnemyPathFinding pathFinding;
    private Vector3 startingPostition;
    private State state;
    private BoxCollider2D cl2;

    private void Awake()
    {
        pathFinding = GetComponent<EnemyPathFinding>();
        state = State.ChasePlayer;
        cl2 = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        startingPostition = transform.position;
    }
    private void Update()
    {
        switch(state)
        {
            case State.ChasePlayer:
                pathFinding.MoveToTimer(Player.Instance.GetPosition());
                break;
            case State.DestroyLight:
                //Implement later
                break;
            default:
                break;
        }
        CheckForCollision();

    }
    private void CheckForCollision()
    {
        if (cl2.IsTouching(Player.Instance.GetCollider())) {
            DealDamage(10);
        }
    }
    public void DealDamage(float dmg)
    {
        Player.Instance.TakeDamage(dmg);
    }
}
