using UnityEngine;

public class RunningState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
      movement.animator.SetBool("Running", true);
    }

    public override void UpdateState(PlayerMovement movement)
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.WalkingState);
        else if(movement.direction.magnitude<0.1f) ExitState(movement, movement.IdleState);
        
        if (movement.VerticalInput < 0) movement.currentMoveSpeed = movement.runBackSpeed;
        else movement.currentMoveSpeed = movement.runSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.PreviousState = this;
            ExitState(movement, movement.JumpingState);
        }
    }
    public void ExitState(PlayerMovement movement, MovementBaseState state)
    {
        movement.animator.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
