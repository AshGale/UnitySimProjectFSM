using UnityEngine;

public class Airborn : AirbornCheck
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Airborn(string name, CreatureSM stateMachine) : base("Airborn", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(!_sm._slamming && Input.GetKeyDown(KeyCode.Space)) {
            _sm._slamming = true;
            base._sm.ChangeState(base._sm.slamingState); 
        }     

        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            //didn't move
            stateMachine.ChangeState(base._sm.idleState);
        } else {
            base._sm.ChangeState(base._sm.flyingState);
        }
    }   
}
