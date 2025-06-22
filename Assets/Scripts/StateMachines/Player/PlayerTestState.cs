using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float secondsLeft = 10f;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}// Basically calls the base constructer and passing in the State Machine it needs

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        secondsLeft -= deltaTime;

        Debug.Log("Seconds left til state switch: " + secondsLeft);

        if (secondsLeft <= 0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }


}
