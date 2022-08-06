using UnityEngine;

public class Slam : Grounded
{
    private CreatureSM _sm;

    public Slam(CreatureSM stateMachine) : base("Slam", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.magenta;

        Vector2 vel = _sm.rigidbody.velocity;
        vel.y -= _sm.jumpForce;
        _sm.rigidbody.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_grounded) {
            stateMachine.ChangeState(_sm.idleState);
        }            
    }

    public override void UpdatePhysics()
    {
        //update if grouned, but don't check for if keypressed
        CheckIfGrounded();
    }

}
