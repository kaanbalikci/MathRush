using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public bool crush;
    public GameObject Cam;
    //public GameObject followWall;
    public int successScore = 3;
    public GameObject gameOverPanel;
    public GameObject mathRoom;
    public GameObject clearArea;
    public Transform playerLastPOS;
    public LayerMask interactable;
    public PlayerBaseState currentState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerMathState MathState = new PlayerMathState();
    public PlayerCrushState CrushState = new PlayerCrushState();
    public PlayerDieState DieState = new PlayerDieState();


    void Start()
    {
        currentState = MoveState;

        currentState.EnterState(this);

        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        StartCoroutine(currentState.StartState(this));
    }
}
