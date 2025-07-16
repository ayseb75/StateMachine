using UnityEngine;

public class Movement : MonoBehaviour
{
    public MovementState[] States;
    private StateMachine<MovementType> stateMachine;
    public float CurrentSpeed;

    PlayerInput input;
    private Rigidbody rb;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        RegisterStates();
        stateMachine.SwitchState(MovementType.Walk);
    }

    private void RegisterStates()
    {
        stateMachine = new StateMachine<MovementType>();
        for (int i = 0; i < States.Length; i++)
        {
            stateMachine.RegisterState(States[i].type, States[i]);
            States[i].movement = this;
        }
    }

    private void Update()
    {
        if (!ReferenceEquals(stateMachine.currentState, null))
        {
            stateMachine.currentState.Tick();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = input.InputVector * CurrentSpeed;
    }

    public float AcceleratingSpeed(float targetSpeed, float acceleration)
    {
        float diff = targetSpeed - CurrentSpeed;
        float deltaSpeed = acceleration * Time.deltaTime;

        if (Mathf.Abs(diff) <= deltaSpeed)
            return targetSpeed;

        return CurrentSpeed + Mathf.Sign(diff) * deltaSpeed;
    }

    public void SwitchState(MovementType type)
    {
        stateMachine.SwitchState(type);
    }
}

public enum MovementType
{
    Walk, Run
}