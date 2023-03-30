using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Logic/Movement/BaseMovement")]
public class BasicMovement : MovementSO
{
    public override void Move(GameObject target, CharacterData data, Vector2 direction)
    {
        var rb = target.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x * data.GetMovementSpeed(), rb.velocity.y);
    }
}
