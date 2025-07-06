using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets = new List<Target>();

    private void OnTriggerEnter(Collider other)
    {
        // If collide with a object that doesnt have Target component dont do anything. If collided gameobject has target component store gameobject to list
        if (!other.TryGetComponent<Target>(out Target target)) { return; } 
        targets.Add(target);
    }

    private void OnTriggerExit(Collider other)
    {
        // If object that exits Targeter collider that doesnt have Target component dont do anything. If collided gameobject that exits Targeter collider has target component remove gameobject from list
        if (!other.TryGetComponent<Target>(out Target target)) { return; }
        targets.Remove(target);
    }
}
