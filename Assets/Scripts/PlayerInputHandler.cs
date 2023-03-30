using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputs inputs;
    [SerializeField] private CharacterData data;


    private Vector2 flipPos;

    private void Start()
    {
        data.SetSelf(this.gameObject);
        data.FacingRight = false;
    }
    private void Update()
    {
        flipPos = GameObject.Find("FlipPos").transform.position;
        data.CheckDir(this.gameObject, flipPos);

        if (Input.GetKey(inputs.Left))
        {
            data.Movement.Move(this.gameObject, data, new Vector2(-1,0));
            data.AnimState = data.FacingRight ? CharacterData.AnimStates.WalkForward : CharacterData.AnimStates.WalkBackward;
        }
        if (Input.GetKey(inputs.Right))
        {
            data.Movement.Move(this.gameObject, data, new Vector2(1, 0));
            data.AnimState = !data.FacingRight ? CharacterData.AnimStates.WalkForward : CharacterData.AnimStates.WalkBackward;
        }
        if(!Input.GetKey(inputs.Right) && !Input.GetKey(inputs.Left))
        {
            data.Movement.Move(this.gameObject, data, new Vector2(0, 0));
            data.AnimState = CharacterData.AnimStates.Idle;
        }
    }
}
