using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Logic")]
    public MovementSO Movement;
    [Header("Variables")]
    public bool FacingRight;
    public float MovementSpeed;
    public float MovementSpeedMultiplier;
    private GameObject self;


    [Header("States")]
    private AnimStates animState;
    public AnimStates AnimState
    {
        get { return animState; }
        set
        {
            if(value != animState)
            {
                animState = value;
                CheckAnimLogic(value);
                self.transform.Find("Sprite").GetComponent<Animator>().Play(value.ToString());
            }
            
        }
    }
    public CCStates CCState;
    public enum CCStates
    {
        None,
        Staggered,
        Stunned,
        Dazed,
        Prone,
    }
    public enum AnimStates
    {
        Idle,
        WalkForward,
        WalkBackward,
        JumpForward,
        JumpBackward,
    }


    #region Getters
    public float GetMovementSpeed()
    {
        return MovementSpeed * MovementSpeedMultiplier;
    }
    #endregion

    #region Setters
    public void SetSelf(GameObject s)
    {
        self = s;
    }
    #endregion

    #region Checks
    public void CheckDir(GameObject target, Vector3 flipPos)
    {
        if ((flipPos.x < target.transform.position.x && !FacingRight) || (flipPos.x > target.transform.position.x && FacingRight))
        {
            FacingRight = !FacingRight;
            if(AnimState != AnimStates.Idle)
            {
                AnimState = AnimState == AnimStates.WalkForward ? AnimStates.WalkBackward : AnimStates.WalkForward;
            }
            target.transform.Rotate(0,-180,0);
        }
    }

    private void CheckAnimLogic(AnimStates state)
    {
        switch (state)
        {
            case AnimStates.Idle:
                break;
            case AnimStates.WalkForward:
                MovementSpeedMultiplier = 1;
                break;
            case AnimStates.WalkBackward:
                MovementSpeedMultiplier = 0.5f;
                break;
        }
    }


    #endregion
}
