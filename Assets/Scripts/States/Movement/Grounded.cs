using System.Diagnostics;
using UnityEngine;

public class Grounded : BaseState
{
    protected CreatureSM _sm;

    public bool _grounded;
    private int _groundLayer = 1 << 6;

    public Grounded(string name, CreatureSM stateMachine) : base(name, stateMachine)
    {
        _sm = (CreatureSM) this.stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        CheckIfGrounded();

        if (_grounded && Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState(_sm.jumpingState);
        }            
    }

    public void CheckIfGrounded() {
        _grounded =  _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}
