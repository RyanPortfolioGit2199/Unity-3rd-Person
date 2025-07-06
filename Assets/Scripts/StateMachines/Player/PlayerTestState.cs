using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float secondsLeft;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}// Basically calls the base constructer and passing in the State Machine it needs

    private Vector3 CameraZ;
    private Vector3 CameraX;

    public override void Enter()
    {
        
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime );

        if (stateMachine.InputReader.MovementValue == Vector2.zero) //If the player isnt moving play the idle animation and dont do any of the code below the If Statement Brackets(return).
        {
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0f, 0.1f, deltaTime); //If player isnt moving play the idle animation
            return; 
        }

        stateMachine.Animator.SetFloat("FreeLookSpeed", 1f, 0.1f, deltaTime); // If player is moving smoothly blend animation from Idle to Running.
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);// Rotate the player based on the Move Keys have been pressed
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        
    }

    private Vector3 CalculateMovement()
    {
        CameraZ = stateMachine.MainCameraTransform.forward;
        CameraX = stateMachine.MainCameraTransform.right;

        //Dont need the camera's pitch (up and down) position for movement calculations so set it to 0
        CameraZ.y = 0f;
        CameraX.y = 0f;

        CameraZ.Normalize();
        CameraX.Normalize();

        return CameraZ * stateMachine.InputReader.MovementValue.y + CameraX * stateMachine.InputReader.MovementValue.x; // This is returning cameras direction multiplied by what Keys the player pressed to move to make sure they move based on which way the camera is facing.
    }


}
