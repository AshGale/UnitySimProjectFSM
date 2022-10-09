using UnityEngine;

public class Jumping : Grounded
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Jumping(CreatureSM stateMachine) : base("Jumping", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);

        _horizontalInput = Input.GetAxis("Horizontal");

        if(_sm.currentEnergy > _sm.jumpCost) {
            //keep here to ensure that only the cost of the jump is taken onces
            //UnityEngine.Debug.Log($"_grounded = {_grounded}");
            Debug.Log("Jumped");
            //UnityEngine.Debug.Log($"_grounded = {_grounded}");
            _sm.currentEnergy -= _sm.jumpCost;
            _sm.spriteRenderer.color = Color.green;
            Vector2 vel = _sm.rigidbody.velocity;
            vel.y += _sm.jumpForce;
            _sm.rigidbody.velocity = vel;
        } else {
            Debug.Log("Net enough energy to Jump");
            stateMachine.ChangeState(_sm.exaustedState);
        }     

        //Has Jumped at this point

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            //didn't move, just jumping
            // stateMachine.ChangeState(base._sm.idleState);
        } else {
            base._sm.ChangeState(base._sm.flightState);
            // if(base._sm.currentEnergy > base._sm.moveCost) {
            //    base._sm.currentEnergy -= base._sm.moveCost;
            // } else {
            //     Debug.Log("Net enough energy to FLY");
            //     base._sm.ChangeState(base._sm.exaustedState);
            // }
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
