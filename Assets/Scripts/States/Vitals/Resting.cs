using UnityEngine;

public class Resting : Grounded
{
    private CreatureSM _sm;


    public Resting(CreatureSM stateMachine) : base("Resting", stateMachine)
    {
        _sm = (CreatureSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        _sm.spriteRenderer.color = Color.yellow;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _sm.movementEnabled = true;
        if(_grounded){
            _sm.currentEnergy += _sm.restEnergy;
        }        

        if (_sm.currentEnergy > _sm.maxEnergy) {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
}
