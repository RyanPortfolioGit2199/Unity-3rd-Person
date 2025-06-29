using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float secondsLeft;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}// Basically calls the base constructer and passing in the State Machine it needs

    public override void Enter()
    {
        
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;
        stateMachine.transform.Translate(movement * deltaTime);
        Debug.Log(stateMachine.InputReader.MovementValue); // Display the Vector2 based on the Movement keys I am pressing and holding.
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        
    }




}
