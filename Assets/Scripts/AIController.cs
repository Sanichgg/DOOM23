using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public enum MoveToCompletedReason
{
    Success,
    Failure,
    Aborted
}


[RequireComponent(typeof(AISense))]
public class AIController : BaceCharacterController
{
    bool isMoveToCompleted = true;
    int pathPointIndex;
    Action<MoveToCompletedReason> moveToCompleted;

    NavMeshPath path;
    AISense sense;

    public AISense Sense => sense;

    protected override void Awake()
    {
        base.Awake();

        path = new NavMeshPath();
        sense = GetComponent<AISense>();
    }



    public bool MoveTo(Vector3 targetPos, Action<MoveToCompletedReason> completed = null)
    {
        if (!isMoveToCompleted)
            AbortMoveTo();

        moveToCompleted = completed;

        bool hasPath = NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);

        if (hasPath)
        {
            if (path.corners.Length == 1)
            {
                InvokeMoveToCompleted(MoveToCompletedReason.Success);
                return true;
            }

            pathPointIndex = 1;
        }
        
        isMoveToCompleted =!hasPath;

        if (!hasPath)
        {
            InvokeMoveToCompleted(MoveToCompletedReason.Failure);
        }

        return hasPath;
    }

    protected virtual void Update()
    {
        if(path.status != NavMeshPathStatus.PathInvalid)
        {
            for(int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }

            if (isMoveToCompleted) return; 

            Vector3 targetPos = path.corners[pathPointIndex];
            Vector3 soursePos = transform.position;

            targetPos.y = 0;
            soursePos.y = 0;

            if (Vector3.Distance(soursePos, targetPos) < 1)
            {
                if (pathPointIndex + 1 >= path.corners.Length)
                {
                    InvokeMoveToCompleted(MoveToCompletedReason.Success);
                    return;
                }
                pathPointIndex++;
                targetPos = path.corners[pathPointIndex];
                targetPos.y = 0;
            }

            Vector3 direction = (targetPos - soursePos).normalized;

            SetRotation(Quaternion.LookRotation(direction, transform.up).eulerAngles.y);
            MoveWorld(direction.x, direction.z);
        }

    }

    void InvokeMoveToCompleted(MoveToCompletedReason reason)
    {
        Action<MoveToCompletedReason> action = moveToCompleted;
        moveToCompleted = null;
        action?.Invoke(reason);
    }
    
    public void AbortMoveTo()
    {
        InvokeMoveToCompleted(MoveToCompletedReason.Aborted);
    }
}
