using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMathState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager player)
    {
        ObjectSpeed.OS.allObjectSpeed = 0f;

        if (MathManager.MM.score / 20 == 1 || MathManager.MM.score / 20 == 2)
        {
            MathManager.MM.countDown = 6;
            MathManager.MM.EasyQuestion();
        }
        else if (MathManager.MM.score / 20 == 3 || MathManager.MM.score / 20 == 4)
        {
            MathManager.MM.countDown = 6;
            MathManager.MM.MediumQuestion();
        }
        else if(MathManager.MM.score / 20 == 5 || MathManager.MM.score / 20 == 6)
        {
            MathManager.MM.countDown = 6;
            MathManager.MM.HardQuestion();
        }
        else if(MathManager.MM.score / 20 == 7 || MathManager.MM.score / 20 == 8)
        {
            MathManager.MM.countDown = 10;
            MathManager.MM.ExpertQuestion();
        }
        else if(MathManager.MM.score / 20 >= 9)
        {
            MathManager.MM.countDown = 20;
            MathManager.MM.DoubleExpertQuestion();
        }
    }
    
    public override void UpdateState(PlayerStateManager player)
    {
        int checkCount = Mathf.FloorToInt(MathManager.MM.countDown);

        if (MathManager.MM.isTrue == "True")
        {
            MathManager.MM.isPlus = true;
            MathManager.MM.isPlayAnim = true;
            MathManager.MM.score += 2;
            player.Cam.transform.Rotate(0, 90, 0);
            player.SwitchState(player.MoveState);
        }
        else if (MathManager.MM.isTrue == "False" || checkCount == 0)
        {
            player.successScore--;
            if(MathManager.MM.score - 10 > 0)
            {
                MathManager.MM.isPlayAnim = true;
                MathManager.MM.isPlayCrush = true;
                MathManager.MM.damageScreen.SetActive(true);
                MathManager.MM.score -= 10;
                player.Cam.transform.Rotate(0, 90, 0);
                player.SwitchState(player.MoveState);
            }
            else
            {
                player.SwitchState(player.DieState);
            }       
        }

        MathManager.MM.isTrue = null;

      
    }

    public override IEnumerator StartState(PlayerStateManager player)
    {

        yield return new WaitForSeconds(0.4f);
        player.transform.position = new Vector3(-77.6f, 11.95f, player.transform.position.z);
        player.Cam.transform.Rotate(0, -90, 0);
        UIManager.UI.scoreText.gameObject.SetActive(false);
        
    }
}
