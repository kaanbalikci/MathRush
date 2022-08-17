using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public virtual void LayerCheck(PlayerStateManager player)
    {
        Collider[] insightRange = Physics.OverlapSphere(player.transform.position, 0.5f, player.interactable);

        if(insightRange.Length > 0)
        {
            if (insightRange[0].gameObject.CompareTag("GlassWall"))
            {               
                player.crush = true;
                insightRange[0].GetComponent<BreakableObjScript>().BreakThis();
            }
        }


    }

    public virtual IEnumerator StartState(PlayerStateManager player)
    {
        yield return null;
    }
}
