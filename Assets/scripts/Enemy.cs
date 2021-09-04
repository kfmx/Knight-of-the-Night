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
    private GameObject targetedTorch;

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
        GameObject[] torches = GameObject.FindGameObjectsWithTag("Torch");
        if (targetedTorch == null) state = State.ChasePlayer;
        for (int i = 0; i < torches.Length; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, torches[i].transform.position) < 5f)
            {
                state = State.DestroyLight;
                targetedTorch = torches[i];
                break;
            } else
            {
                state = State.ChasePlayer;
            }
        }

        switch(state)
        {
            case State.ChasePlayer:
                pathFinding.MoveToTimer(Player.Instance.GetPosition());

                break;
            case State.DestroyLight:
                pathFinding.MoveToTimer(targetedTorch.transform.position);
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
        } else if (targetedTorch != null)
        {
            DealDamageToTorch();
        }
    }
    public void DealDamage(float dmg)
    {
        Player.Instance.TakeDamage(dmg);
    }

    public void DealDamageToTorch()
    {
        targetedTorch.GetComponent<TorchHealth>().TakeDamage(10);
    }
}
