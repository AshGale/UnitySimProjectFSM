﻿using UnityEngine;

public class Jumping : Airborn
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Jumping(string name, CreatureSM stateMachine) : base("Jumping", stateMachine) 
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.green;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            stateMachine.ChangeState(base._sm.idleState);
        } else {
            //might need to add for seamless jumping moving ?
            //base._sm.ChangeState(base._sm.movingState)
        }
    }

    public override void UpdatePhysics()
    {      
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.y += _sm.jumpForce;
        _sm.rigidbody.velocity = vel;
    }

}
