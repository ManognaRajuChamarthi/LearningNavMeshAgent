using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Abstract
{
    public override void EnterState(Context ctx)
    {
        Debug.Log("Hello");
    }

    public override void UpdateState(Context ctx)
    {
        if((ctx.Transform.position - ctx.IPTransform.position).sqrMagnitude <= Mathf.Pow(ctx.DetectionDistance*2, 2))
        {
            ctx.Agent.SetDestination(ctx.IPTransform.position);
            ctx.Agent.speed = ctx.WanderSpeed * 1.5f;
            Debug.Log(ctx.Agent.speed);
        }
        else
        {
            ctx.SwitchMovementStates(ctx._wanderState);
        }
        
    }

    public override void FixedUpdateState(Context ctx)
    {

    }

    public override void ExitState(Context ctx)
    {

    }
}
