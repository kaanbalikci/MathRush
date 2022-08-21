using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrushState : PlayerBaseState
{
    private List<GameObject> ballList = new List<GameObject>();

    private float xCount = 2;
    
    public override void EnterState(PlayerStateManager player)
    {
        MathManager.MM.isPlayCrush = true;
        Debug.Log("Crush");
        CameraShake.instance.ShakeCam(20, 0.4f);

        Vector3 backPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 4);
        player.playerLastPOS.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z -2);
        player.transform.position = Vector3.Lerp(player.transform.position, backPos, 3f);
        //StartState(player);

        player.crush = false;

        if((MathManager.MM.score-3)% 20 == 0)
        {
            MathManager.MM.score -= 4;
        }
        else
        {
            MathManager.MM.score -= 3;
        }

    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override IEnumerator StartState(PlayerStateManager player)
    {
        
        yield return new WaitForSeconds(1f);
        player.SwitchState(player.MoveState);
        
    }
}
