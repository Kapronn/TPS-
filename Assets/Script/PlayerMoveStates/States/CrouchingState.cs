using UnityEngine;

public class CrouchingState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
        movement.animator.SetBool("Crouching", true);
    }

    public override void UpdateState(PlayerMovement movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.RunningState);
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(movement.direction.magnitude<0.1f) ExitState(movement, movement.IdleState);
            else ExitState(movement, movement.WalkingState);
        }
        
        if (movement.VerticalInput < 0) movement.currentMoveSpeed = movement.crouchBackSpeed;
        else movement.currentMoveSpeed = movement.crouchSpeed;
    }
    public void ExitState(PlayerMovement movement, MovementBaseState state)
    {
        movement.animator.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}