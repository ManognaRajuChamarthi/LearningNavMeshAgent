using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : Abstract
{
    private float _elapsedTimeForDirectionChange;
    private Vector3 _finalPosition;

    public override void EnterState(Context ctx)
    {
        _elapsedTimeForDirectionChange = ctx.WaitTimeBeforeMovingToNewPostion;
        
    }


    public override void UpdateState(Context ctx)
    {
        ChoosingNewPositionToMove(ctx.PatrolArea, ctx);
        ctx.Agent.SetDestination(_finalPosition);
        if((ctx.Transform.position - ctx.IPTransform.position).sqrMagnitude <= Mathf.Pow(ctx.DetectionDistance, 2))
        {
            ctx.SwitchMovementStates(ctx._chaseState);
        }
    }


    public override void FixedUpdateState(Context ctx)
    {
        
    }


    public override void ExitState(Context ctx)
    {
        
    }


    void ChoosingNewPositionToMove(float radius, Context ctx)
    {
        if (_elapsedTimeForDirectionChange > 0)
        {
            _elapsedTimeForDirectionChange -= Time.deltaTime;
        }
        else
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += ctx.StartPosition;
            NavMeshHit hit;
            _finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                _finalPosition= hit.position;
            }
            _elapsedTimeForDirectionChange = ctx.WaitTimeBeforeMovingToNewPostion;
        }

    }
}
