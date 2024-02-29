using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingState : MovementState
{

    public JumpingState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Jumping  - Enter");        
    
        
        //playerRigidbody.velocity = Vector2.up * _jampForce;
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Jumping  - Exit");
    }

    //public override void Update()
    //{
    //    base.Update();
    //    Debug.Log("Jumping  - Update");
    //}
}
