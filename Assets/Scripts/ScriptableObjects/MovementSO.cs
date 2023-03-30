using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementSO : ScriptableObject
{
    public virtual void Move(GameObject target, CharacterData data, Vector2 direction)
    {
        Debug.Log($"{target.gameObject.name} needs to move in the direction of: '{direction}' using the stats from {data.name}");
    }
}
