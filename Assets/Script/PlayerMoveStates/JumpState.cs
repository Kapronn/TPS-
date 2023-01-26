

using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
        if(movement.PreviousState == movement.IdleState) movement.animator.SetTrigger("IdleJump");
        else if (movement.PreviousState == movement.WalkingState || movement.PreviousState == movement.RunningState) 
            movement.animator.SetTrigger("RunningJump");
            
            
             
        
    }

    public override void UpdateState(PlayerMovement movement)
    {
        if (movement.jumped && movement.IsGrounded())
        {
            movement.jumped = false;
            if(movement.HorizontalInput == 0 && movement.VerticalInput == 0) movement.SwitchState(movement.IdleState);
            else if(Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.RunningState);
            else movement.SwitchState(movement.WalkingState);

        }
    }
}
