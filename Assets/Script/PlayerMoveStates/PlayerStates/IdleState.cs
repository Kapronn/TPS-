using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(PlayerMovement movement)
    {
        
    }

    public override void UpdateState(PlayerMovement movement)
    {
        if (movement.direction.magnitude > 0.1f)
        {
            if(Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.RunningState);
            else movement.SwitchState(movement.WalkingState);
        }
        if(Input.GetKeyDown(KeyCode.C)) movement.SwitchState(movement.CrouchingState); 
    }
}
