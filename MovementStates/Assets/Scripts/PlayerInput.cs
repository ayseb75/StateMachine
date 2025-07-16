using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public Vector3 InputVector;
    public bool IsMoving;

    private Vector3 smoothInput,smoothVelocity;

    [SerializeField] float inputSmoother;

    Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        IsMoving = xInput != 0 || zInput != 0;

        Vector3 inputDir = new Vector3(xInput, 0, zInput).normalized;
        smoothInput = Vector3.SmoothDamp(smoothInput, inputDir, ref smoothVelocity, inputSmoother);

        InputVector = smoothInput;

        if (Input.GetKeyDown(KeyCode.LeftShift)) { movement.SwitchState(MovementType.Run); }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { movement.SwitchState(MovementType.Walk); }
    }
}
