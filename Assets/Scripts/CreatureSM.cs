using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is essentially the player controller
*/
public class CreatureSM : StateMachine
{
    public float speed = 4f;
    public float jumpForce = 6f;
    public float moveCost = 0.01f;
    public float jumpCost = 1f;
    public float slamCost = 2f;

    public float currentEnergy = 4f;
    public int minEnergy = 2;
    public int maxEnergy = 10;
    public float restEnergy = .02f;

    public bool movementEnabled = true;


    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jumping jumpingState;
    [HideInInspector]
    public Slam slamState;

    [HideInInspector]
    public Exausted exaustedState;
    [HideInInspector]
    public Resting restingState;
    [HideInInspector]
    public Steady steadyState;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
        slamState = new Slam(this);

        exaustedState = new Exausted(this);
        restingState = new Resting(this);
        steadyState = new Steady(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
