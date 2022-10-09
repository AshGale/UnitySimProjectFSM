using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is essentially the player controller
*/
public class CreatureSM : StateMachine
{
    public bool _jumping = false;
    public bool _slamming = false;

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
    public Airborn airbornState;
    [HideInInspector]
    public AirbornCheck airbornCheckState;
    [HideInInspector]
    public Flying flyingState;
    [HideInInspector]
    public Grounded groundedState;
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Jumping jumpingState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Slaming slamingState;


    private void Awake()
    {
        airbornState = new Airborn("", this);
        airbornCheckState = new AirbornCheck("", this);
        flyingState = new Flying("", this);
        groundedState = new Grounded("", this);
        idleState = new Idle(this);
        jumpingState = new Jumping("", this);
        movingState = new Moving("", this);
        slamingState = new Slaming("", this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
