using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float speed = 5f;
    private Vector3 answerPOS = new Vector3(-77.6f, 11.95f, -71f);
    public override void EnterState(PlayerStateManager player)
    {
        //ObjectSpeed.OS.allObjectSpeed = 100f;
        
    }

    public override void UpdateState(PlayerStateManager player)
    {

        //player.transform.Translate(0, 0, speed * Time.deltaTime);

        //Transform Wall = player.followWall.transform;
        Transform mathRoom = player.mathRoom.transform;

        player.mathRoom.transform.position = new Vector3(mathRoom.position.x, mathRoom.position.y, player.transform.position.z);
        //player.followWall.transform.position = new Vector3(Wall.position.x, Wall.position.y, player.transform.position.z + +100);
        
        

        base.LayerCheck(player);

        if (player.crush == true)
        {
            player.SwitchState(player.CrushState);
        }

        if (MathManager.MM.score / 20 == player.successScore /*&& MathManager.MM.score != 0*/)
        {
            player.successScore++;
            player.playerLastPOS.position = player.transform.position;
            MathManager.MM.isPlayAnim = true;
            player.SwitchState(player.MathState);
            
        }

        if (Input.GetMouseButtonDown(0) && MathManager.MM.score != 0)
        { 
            MathManager.MM.score -= 1;
          
        }
        if(MathManager.MM.isDie == true)
        {
            player.SwitchState(player.DieState);
        }
        

    
    }
    public override IEnumerator StartState(PlayerStateManager player)
    {

        
        yield return new WaitForSeconds(0.4f);
        player.transform.position = player.playerLastPOS.position;
        MathManager.MM.damageScreen.SetActive(false);
        UIManager.UI.scoreText.gameObject.SetActive(true);
        HeartUI.HU.Hearts.gameObject.SetActive(true);

        if (player.Cam.transform.rotation.y != 0)
        {
            player.Cam.transform.Rotate(0, 90, 0);
        }
        
    }

}
