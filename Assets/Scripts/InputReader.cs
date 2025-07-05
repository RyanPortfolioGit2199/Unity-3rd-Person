using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions  // On this line we have this class(Input Reader) and it is inheriting MonoBehaviour(since you can only inherit 1 class) after a comma is an interface. Basically a contract with the input system that says we promise in this class to have methods called and whatever they maybe.
{
    public Vector2 MovementValue {  get; private set; }
       
    // Using events to let the state know we jumped, basically link this class to the state.
    public event Action JumpEvent; 
    public event Action DodgeEvent;
    // Events are things that are triggered when they happened as opposed to something you pull, you check every single frame

    private Controls controls;

    private void Start()
    {
        controls = new Controls(); // Needed to create an instance of the Controls script here(in the Input Reader script) basically storing that class here in this script to get access to the Control scripts to listen for the Buttons pressed that we set in the Controls script.
        controls.Player.SetCallbacks(this); // Basically this line means whenever a button(the buttons set in the Controls script) to call the methods attached to it (ie: Pressing spacebar will call the OnJump method)
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context) // The context mentioned on this line is used for when a button we set is pressed, when it gets released, when it is held ex., we use the context to check for when the button is triggered a certain way do this.
    {
        if(!context.performed) { return; } // Basically if the button hasn't been pressed dont do anything but if it has been pressed do the JumpEvent.

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();// When Move keys are held make the Vector2 values equal MovementValue
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }
}
