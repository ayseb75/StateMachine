using UnityEngine;

[System.Serializable]
public class MovementState : IState
{
    public MovementType type;

    public float TargetSpeed, Acceleration;

    [HideInInspector] public Movement movement;

    public void Enter()
    {
        Debug.Log(type + " State Entered");
    }

    public void Tick()
    {
        Debug.Log(type + " State Playing");

        movement.CurrentSpeed = movement.AcceleratingSpeed(TargetSpeed, Acceleration);
    }

    public void Exit()
    {
        Debug.Log(type + " State Exit");
    }
}