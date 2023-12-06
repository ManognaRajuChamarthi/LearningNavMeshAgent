using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract
{

    public abstract void EnterState(Context ctx);

    public abstract void UpdateState(Context ctx);

    public abstract void FixedUpdateState(Context ctx);

    public abstract void ExitState(Context ctx);
}
