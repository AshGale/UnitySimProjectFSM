﻿using UnityEngine;

public class Moving : Grounded
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Moving(CreatureSM stateMachine) : base("Moving", stateMachine) {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        base._sm.spriteRenderer.color = Color.grey;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            stateMachine.ChangeState(base._sm.idleState);
        } else {
            if(base._sm.currentEnergy > base._sm.moveCost) {
               base._sm.currentEnergy -= base._sm.moveCost;
            } else {
                Debug.Log("Net enough energy to Move");
                base._sm.ChangeState(base._sm.exaustedState);
            }
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
        Vector2 vel = base._sm.rigidbody.velocity;
        vel.x = _horizontalInput * ((CreatureSM)stateMachine).speed;
        base._sm.rigidbody.velocity = vel;
    }

}
