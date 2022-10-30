using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Die");
        CameraShake.instance.ShakeCam(20, 1f);
        Time.timeScale = 0.2f;
        

    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override IEnumerator StartState(PlayerStateManager player)
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
        player.gameOverPanel.SetActive(true);
    }
}
