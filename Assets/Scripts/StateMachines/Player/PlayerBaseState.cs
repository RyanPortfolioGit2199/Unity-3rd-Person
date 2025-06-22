using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)// This is a constructer(Look up more indepth later)
    {
        this.stateMachine = stateMachine;
    }
}
