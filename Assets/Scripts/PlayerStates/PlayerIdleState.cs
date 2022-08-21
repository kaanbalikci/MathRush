using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.SwitchState(player.MoveState);
        Debug.Log("degisiyorum");
    }

    public override void UpdateState(PlayerStateManager player)
    {
       
    }
}
