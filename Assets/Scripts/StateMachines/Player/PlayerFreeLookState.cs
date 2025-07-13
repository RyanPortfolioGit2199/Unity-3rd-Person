using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private float secondsLeft;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) {}// Basically calls the base constructer and passing in the State Machine it needs

    private Vector3 CameraZ;
    private Vector3 CameraX;

    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLook BlendTree");
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed"); // Converting FreeLookSpeed string from a string to an integer because strings need more processing power to get reference to compared to integers.

    private const float AnimatorDampTime = 0.1f;

    public override void Enter()
    {
        stateMachine.Animator.Play(FreeLookBlendTreeHash);
        stateMachine.InputReader.TargetLockEvent += OnTarget;
        Debug.Log("Enter");
        stateMachine.isTargeting = false;
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero) //If the player isnt moving play the idle animation and dont do any of the code below the If Statement Brackets(return).
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f, AnimatorDampTime, deltaTime); //If player isnt moving play the idle animation
            return;
        }

        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1f, AnimatorDampTime, deltaTime); // If player is moving smoothly blend animation from Idle to Running.
        FaceMovementDirection(movement, deltaTime);
    }



    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputReader.TargetLockEvent -= OnTarget;
    }

    private void OnTarget()
    {
        if (!stateMachine.Targeter.SelectTarget() && stateMachine.isTargeting) { return; }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));

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

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        // Rotate the player based on the Move Keys have been pressed
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation, 
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping);
        // using Lerp to smoothly transition from 1 direction to another when rotating the player so it is not so snappy looking.
    }
}
