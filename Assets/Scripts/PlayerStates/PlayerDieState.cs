using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        CameraShake.instance.ShakeCam(20, 1f);
       
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}
