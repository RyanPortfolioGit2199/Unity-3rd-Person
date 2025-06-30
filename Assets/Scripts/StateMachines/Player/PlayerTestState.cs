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
        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime );

        if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; } //If the player isnt moving dont do any calculations.

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);// Rotate the player based on the Move Keys have been pressed
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        
    }




}
