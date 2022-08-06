using UnityEngine;

public class Grounded : BaseState
{
    protected CreatureSM sm;

    public bool _grounded;
    private int _groundLayer = 1 << 6;

    public Grounded(string name, CreatureSM stateMachine) : base(name, stateMachine)
    {
        sm = (CreatureSM) this.stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        CheckIfGrounded();

        if (_grounded && Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState(sm.jumpingState);
        }            
    }

    public void CheckIfGrounded() {
        _grounded =  sm.rigidbody.velocity.y < Mathf.Epsilon && sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}
