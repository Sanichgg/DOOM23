using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamingAIState : AIState
{
    public AIController AIController { get; }
    public RoamingAIState(AIController aIControlller, AIStateMachine stateMachine) : base(stateMachine)
    {
        AIController = aIControlller;
    }
    public override void Disable()
    {
        
    }

    public override void Enable()
    {
        AIController.MoveTo(GetRandomPosInRadius(10), HandleMoveToCompleted); // HandleMoveToCompleted можно записать так -, () => Debug.Log("COMPLETED");
    }
    void HandleMoveToCompleted(MoveToCompletedReason reason)
    {
        Debug.Log(reason);

        if (reason == MoveToCompletedReason.Failure) return;

        ChangeState("Roaming");
    }
           
    
    Vector3 GetRandomPosInRadius(float radius)
    {
        Vector3 randomDir = Random.insideUnitSphere * radius;
        Vector3 TargetPos = AIController.transform.position + randomDir;

        if (NavMesh.SamplePosition(TargetPos, out NavMeshHit hit, radius, NavMesh.AllAreas))
            return hit.position;
        else
            return AIController.transform.position;
        

    }
}
