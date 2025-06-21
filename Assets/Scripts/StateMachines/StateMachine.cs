using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// What a state machine really does is it stores the current state and it has a way to switch between states
public abstract class StateMachine : MonoBehaviour // we are keeping the monobehaviour because we will be sticking this on gameobjects
{
    private State currentState; // a private State Variable so we know which state we are in at all times

    public void SwitchState(State newState) 
    {
        currentState?.Exit(); // If currentState isnt null, We want to exit the current state
        currentState = newState; // This line is switching to the new state after we exited the previous state in the code above
        currentState.Enter(); // Since we switched to the new state we have to enter that state
    }

    // Update is called once per frame
    private void Update()
    {
        currentState?.Tick(Time.deltaTime); // The ? is a short hand to use instead of writing out a if statement to check if something is null or not; It is called a null conditional operator.
    }

    
}
