using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerControlscheme")]
public class PlayerInputs : ScriptableObject
{
    [Header("Movement")]
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public KeyCode Crouch;
    public KeyCode DashRight;
    public KeyCode DashLeft;

    [Header("Offensive")]
    public KeyCode BasicAttack;
    public KeyCode SpecialAttack;
    public KeyCode UltimateAttack;

    [Header("Defensive")]
    public KeyCode Block;

    [Header("Recovery")]
    public KeyCode recover;

    [Header("Augments")]
    public KeyCode Augment1;
    public KeyCode Augment2;

}
