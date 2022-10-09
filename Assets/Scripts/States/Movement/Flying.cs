using UnityEngine;

public class Flying : Airborn
{
    private CreatureSM _sm;
    private float _horizontalInput;

    public Flying(string name, CreatureSM stateMachine) : base("Flying", stateMachine) 
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        base._sm.spriteRenderer.color = Color.grey;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon) {
            stateMachine.ChangeState(base._sm.idleState);
        } 
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector2 vel = base._sm.rigidbody.velocity;
        vel.x = _horizontalInput * ((CreatureSM)stateMachine).speed;
        base._sm.rigidbody.velocity = vel;
    }

}
