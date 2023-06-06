using UnityEngine;

namespace SuperVeigar
{
    public class PlayerStateDead : PlayerState
    {
        public override void Reset(Animator animator)
        {
            nextStateType = PlayerStateType.Dead;
            animator.SetTrigger("Dead");
        }
    }
}
