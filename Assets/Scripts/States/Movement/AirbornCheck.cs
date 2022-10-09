using System.Globalization;
using System.Diagnostics;
using UnityEngine;

public class AirbornCheck : BaseState
{
    protected CreatureSM _sm;

    public bool _touchingGround;

    private int _groundLayer = 1 << 6;

    public AirbornCheck(string name, CreatureSM stateMachine) : base("AirBornCheck", stateMachine)
    {
        _sm = (CreatureSM) this.stateMachine;
    }

     public override void Enter()
    {
        base.Enter();
        UnityEngine.Debug.Log(this.name);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        CheckIfGrounded();

        if (_touchingGround) {
            UnityEngine.Debug.Log("______________________________________");
            _sm._jumping = false;//hit ground after a jump
            _sm._slamming = false;//hit the ground after slamming to the ground
            stateMachine.ChangeState(_sm.groundedState);            
        } else {
            UnityEngine.Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            stateMachine.ChangeState(_sm.airbornState);
        }
    }

    public void CheckIfGrounded() {
        _touchingGround =  _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}
