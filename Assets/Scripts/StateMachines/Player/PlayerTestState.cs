using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float secondsLeft;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}// Basically calls the base constructer and passing in the State Machine it needs

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump; // when pressing spacebar(from InputReader) Enter Player Test State
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        secondsLeft += deltaTime;

        Debug.Log(secondsLeft);
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputReader.JumpEvent -= OnJump; // When pressing spacebar again exit PlayerTestState
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }


}
