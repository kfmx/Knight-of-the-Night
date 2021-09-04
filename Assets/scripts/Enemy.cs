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

    private void Awake()
    {
        pathFinding = GetComponent<EnemyPathFinding>();
        state = State.ChasePlayer;
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
                pathFinding.MoveToTimer(player.Instance.GetPosition());
                break;
            case State.DestroyLight:
                //Implement later
                break;
            default:
                break;
        }
    }

}
