using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.animator.SetBool("Aiming", false);
    }
    
    public override void UpdateState(AimStateManager aim)
    {
        if(Input.GetKey(KeyCode.Mouse1)) aim.SwitchState(aim.Aim);
    }
    
}
