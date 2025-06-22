using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine // The class on the right of the : is what is being inherited(Meaning this script gains access to all of the Methods, variables, functions, data etc inside the class)
    // This script will be attached to a gameobject but dont have to worry about getting an error for not inheriting MonoBehaviour in this script, since this script is inheriting the StateMachine script(which inherits Monobehaviour) we can attach this script to gameobjects
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new PlayerTestState(this));
    }

    // Update is called once per frame
    protected override void Update() // Had to make this one override in order to run the StateMachine Update here in this script
    {
        base.Update(); 
    }
}
