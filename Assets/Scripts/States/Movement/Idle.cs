using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle (CreatureSM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
        sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon) {
            stateMachine.ChangeState(sm.movingState);
        } else {
            //When there is no movement, check if you can rest
            if(_grounded) {
                if (sm.currentEnergy < sm.maxEnergy) {
                    Debug.Log("Resting");
                    stateMachine.ChangeState(sm.restingState);
                    // sm.currentEnergy += sm.restEnergy;
                    // sm.spriteRenderer.color = Color.yellow;
                } else {
                    //Debug.Log("Fully Rested, now Idle");Spams
                    // sm.spriteRenderer.color = Color.black;
                }
            } else {
                Debug.Log("In the Air still, but Idle");
                // sm.spriteRenderer.color = Color.black;
            }           
        } 
    }
}
