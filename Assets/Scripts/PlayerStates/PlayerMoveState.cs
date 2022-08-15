using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float speed = 5f;
    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {     
        player.transform.Translate(0, 0, speed * Time.deltaTime);

        Transform Wall = player.followWall.transform;
        player.followWall.transform.position = new Vector3(Wall.position.x, Wall.position.y, player.transform.position.z + + 100);


        base.LayerCheck(player);

        if(player.crush == true)
        {
            player.SwitchState(player.CrushState);
        }
    }
}
