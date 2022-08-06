using UnityEngine;

public class Moving : Grounded
{
    private float _horizontalInput;

    public Moving(CreatureSM stateMachine) : base("Moving", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        sm.spriteRenderer.color = Color.grey;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        /*
            TODO Make this a Parent Class and have the states that can move, inherit from it



        */






        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            stateMachine.ChangeState(sm.idleState);
        } else {
            if(sm.currentEnergy > sm.moveCost) {
               sm.currentEnergy -= sm.moveCost;
            } else {
                Debug.Log("Net enough energy to Move");
                sm.ChangeState(sm.exaustedState);
            }
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
        Vector2 vel = sm.rigidbody.velocity;
        vel.x = _horizontalInput * ((CreatureSM)stateMachine).speed;
        sm.rigidbody.velocity = vel;
    }

}
