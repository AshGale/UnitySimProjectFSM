using UnityEngine;

//state that is when energy hits 0
public class Exausted : BaseState
{
    private CreatureSM _sm;

    private bool _grounded;
    private int _groundLayer = 1 << 6;

    public Exausted(CreatureSM stateMachine) : base("Exausted", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.red;        
        _sm.movementEnabled = false;
        
        //?
        // _sm.rigidbody.velocity = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(_grounded)
        _sm.currentEnergy += _sm.restEnergy;

        if (_sm.currentEnergy > _sm.minEnergy) {
            Debug.Log("Not Exausted anymore");
            _sm.movementEnabled = true;
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        //ensure touching the ground
        base.UpdatePhysics();
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }

}
