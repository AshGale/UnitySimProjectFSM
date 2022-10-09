using UnityEngine;

public class Grounded : AirbornCheck
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Grounded(string name, CreatureSM stateMachine) : base("Grounded", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        base._sm.spriteRenderer.color = Color.green;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(!_sm._jumping && !_sm._slamming && Input.GetKeyDown(KeyCode.Space)) {
            _sm._jumping = true;
            base._sm.ChangeState(base._sm.jumpingState);           
        }     

        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            //didn't move
            stateMachine.ChangeState(base._sm.idleState);
        } else {
            base._sm.ChangeState(base._sm.movingState);
        }
    }
}
