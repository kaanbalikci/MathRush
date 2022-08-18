using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("DIE STATE");
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}
