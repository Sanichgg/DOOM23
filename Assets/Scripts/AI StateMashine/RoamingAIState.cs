using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamingAIState : AIState
{
    public AIController AIController { get; }

    public RoamingAIState(AIController aIController, AIStateMachine stateMachine) : base(stateMachine)
    {
        AIController = aIController;
        
    }
    
    public override void Enable()
    {
        AIController.MoveTo(GetRandomPosInRadius(10), HandleMoveToCompleted); // HandleMoveToCompleted можно записать так -, () => Debug.Log("COMPLETED");
        AIController.Sense.TargetChanged += HandleTargetChanged;
    }

    public override void Disable()
    {
        AIController.Sense.TargetChanged -= HandleTargetChanged;

    }

    void HandleTargetChanged(DamagebleComponent target)
    {
        if(target != null)
        {
            AIController.AbortMoveTo();
            ChangeState("Chasing");
        }
    }

    
    void HandleMoveToCompleted(MoveToCompletedReason reason)
    {
        Debug.Log(reason);

        if (reason != MoveToCompletedReason.Success) return;

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
