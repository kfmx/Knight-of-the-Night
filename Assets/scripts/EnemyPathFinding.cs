using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{

    private EnemyMain enemyMain;
    private const float speed = 5f;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float pathFindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Awake()
    {
        enemyMain = GetComponent<EnemyMain>();
    }

    private void Update()
    {
        pathFindingTimer -= Time.deltaTime;

        HandleMovement();
    }

    private void FixedUpdate()
    {
        enemyMain.mine.velocity = moveDir * speed;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        SetTargetPosition(targetPosition);
    }

    public void MoveToTimer(Vector3 targetPosition)
    {
        if (pathFindingTimer <= 0f)
        {
            SetTargetPosition(targetPosition);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;

        pathVectorList = FindPath(GetPosition(), targetPosition);

        pathFindingTimer = 0.1f;
    }

    public void StopMoving()
    {
        pathVectorList = null;
        moveDir = Vector3.zero;
    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            float reachedTargetDistance = 1f;
            if (Vector3.Distance(GetPosition(), targetPosition) > reachedTargetDistance)
            {
                moveDir = (targetPosition - GetPosition()).normalized;
                lastMoveDir = moveDir;
                if (currentPathIndex < pathVectorList.Count-1)
                {
                    currentPathIndex++;
                }
            } else
            {
                StopMoving();
            }   
        }
    }

    private List<Vector3> FindPath(Vector3 myPos, Vector3 targetPos)
    {
        List<Vector3> newList = new List<Vector3>();
        Vector3 currentPos = GetPosition();
        Vector3 moveDir = (targetPos - currentPos).normalized;

        for (int i = 0; i < 10; i++) {
            
            newList.Add(new Vector3(currentPos.x + moveDir.x * i+1, currentPos.y + moveDir.y * i+1));
        }

        return newList;
    }

    private Vector3 GetPosition()
    {
        return enemyMain.transform.position;
    }
}
