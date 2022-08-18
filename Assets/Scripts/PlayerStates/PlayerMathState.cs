using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMathState : PlayerBaseState
{
    private float time = 5;
    private Vector3 answerPOS = new Vector3(-77.6f, 11.95f, -65.8f);


    public override void EnterState(PlayerStateManager player)
    {
        player.transform.position = answerPOS;
        player.Cam.transform.Rotate(0, -90, 0);
        UIManager.UI.scoreText.gameObject.SetActive(false);
        MathManager.MM.countDown = 5;

        if(MathManager.MM.score / 20 == 1 || MathManager.MM.score / 20 == 2)
        {
            Debug.Log("EASY GIRDI");
            MathManager.MM.EasyQuestion();
        }
    }
    
    public override void UpdateState(PlayerStateManager player)
    {
        if(Mathf.FloorToInt(MathManager.MM.countDown) == 0 )
        {
  
        }

        if (MathManager.MM.isTrue == "True")
        {
            MathManager.MM.score += 15;
            player.Cam.transform.Rotate(0, 90, 0);
            player.SwitchState(player.MoveState);
        }
        else if (MathManager.MM.isTrue == "False")
        {
            player.SwitchState(player.DieState);
        }

        MathManager.MM.isTrue = null;
    }
}
