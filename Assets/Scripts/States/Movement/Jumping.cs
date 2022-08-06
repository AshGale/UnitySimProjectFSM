using UnityEngine;

public class Jumping : Grounded
{
    private CreatureSM _sm;

    public Jumping(CreatureSM stateMachine) : base("Jumping", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);

        if(_sm.currentEnergy > _sm.jumpCost) {
            //keep here to ensure that only the cost of the jump is taken onces
            Debug.Log("Jumped");
            _sm.currentEnergy -= _sm.jumpCost;
            _sm.spriteRenderer.color = Color.green;
            Vector2 vel = _sm.rigidbody.velocity;
            vel.y += _sm.jumpForce;
            _sm.rigidbody.velocity = vel;
        } else {
            Debug.Log("Net enough energy to Jump");
            stateMachine.ChangeState(_sm.idleState);
        }     
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_grounded) {
             stateMachine.ChangeState(_sm.idleState);
        } else {
            if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(_sm.slamState);
        }           
    }
}
