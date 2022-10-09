using UnityEngine;

public class Idle : BaseState
{
    private CreatureSM _sm;

    private float _horizontalInput;

    public Idle (CreatureSM stateMachine) : base("Idle", stateMachine) {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon) {
            stateMachine.ChangeState(_sm.airbornCheckState);
        } 
    }
}
