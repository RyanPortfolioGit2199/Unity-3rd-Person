using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.isTargeting = true;
        stateMachine.InputReader.TargetLockEvent += OnCancel;
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        stateMachine.InputReader.TargetLockEvent -= OnCancel;
    }

    private void OnCancel()
    {
        if (stateMachine.isTargeting == false) { return; }
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }
}
