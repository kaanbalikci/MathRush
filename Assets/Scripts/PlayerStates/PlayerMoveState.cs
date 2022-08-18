using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float speed = 5f;
    private Vector3 answerPOS = new Vector3(-77.6f, 11.95f, -65.8f);
    public override void EnterState(PlayerStateManager player)
    {
        player.transform.position = player.playerLastPOS.position;
        UIManager.UI.scoreText.gameObject.SetActive(true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
        player.transform.Translate(0, 0, speed * Time.deltaTime);

        Transform Wall = player.followWall.transform;
        player.followWall.transform.position = new Vector3(Wall.position.x, Wall.position.y, player.transform.position.z + + 100);
        
        player.playerLastPOS.position = player.transform.position;

        base.LayerCheck(player);

        if(player.crush == true)
        {
            player.SwitchState(player.CrushState);
        }

        if(MathManager.MM.score % 20 == 0)
        {
           
            player.SwitchState(player.MathState);
        }
    }
}
