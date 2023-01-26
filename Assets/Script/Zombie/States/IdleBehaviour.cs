using UnityEngine;
public class IdleBehaviour : StateMachineBehaviour
{
    private Transform _player;
    private float _chastRange = 10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if (distance<_chastRange) animator.SetBool("IsChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}