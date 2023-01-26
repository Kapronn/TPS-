using Unity.VisualScripting;
using UnityEngine;

public class WalkingState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
        movement.animator.SetBool("Walking", true);
    }

    public override void UpdateState(PlayerMovement movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.RunningState);
        else if (Input.GetKeyDown(KeyCode.C)) ExitState(movement, movement.CrouchingState);
        else if (movement.direction.magnitude < 0.1f) ExitState(movement, movement.IdleState);

        if (movement.VerticalInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.PreviousState = this;
            ExitState(movement, movement.JumpingState);
        }
    }

    public void ExitState(PlayerMovement movement, MovementBaseState state)
    {
        movement.animator.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}