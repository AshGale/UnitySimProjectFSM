using UnityEngine;

//state that is active when vital are normal
public class Steady : BaseState
{
    private CreatureSM _sm;

    public Steady(CreatureSM stateMachine) : base("Steady", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.black;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
    }

}
