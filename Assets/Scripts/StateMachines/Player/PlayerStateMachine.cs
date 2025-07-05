using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine // The class on the right of the : is what is being inherited(Meaning this script gains access to all of the Methods, variables, functions, data etc inside the class)
    // This script will be attached to a gameobject but dont have to worry about getting an error for not inheriting MonoBehaviour in this script, since this script is inheriting the StateMachine script(which inherits Monobehaviour) we can attach this script to gameobjects
{
    // Since you are unable to serialise a property we use field: SerializeField which is a under the hood command to make the field for us to use this property in the inspector
    [field: SerializeField]public InputReader InputReader { get; private set; } //Needs to get access to the InputReader script but dont want any of the State scripts to be able to modify the InputReader Script. So used { get; private set; }, "get" meaning get asses to the script, but set it to private to only referance and not change anything in InputReader script.
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }

    [field: SerializeField] public Animator Animator { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new PlayerTestState(this)); // When starting the game change to the PlayerTestState
    }

    // Update is called once per frame
    protected override void Update() // Had to make this one override in order to run the StateMachine Update here in this script
    {
        base.Update(); 
    }
}
