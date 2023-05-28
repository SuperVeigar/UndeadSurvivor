using UnityEngine;

namespace SuperVeigar
{
    public class PlayerStateStand : PlayerState
    {
        public override void Reset(Animator animator)
        {
            nextStateType = PlayerStateType.Stand;
            animator.SetBool("Run", false);
        }

        public override void UpdateState(Vector2 move, float attack, GameObject player, GameObject weapon, int moveSpeed)
        {
            base.UpdateState(move, attack, player, weapon, moveSpeed);

            SetRunOrStand(move);
        }

        public override bool IsNextStateSwitched()
        {
            return nextStateType != PlayerStateType.Stand;
        }
    }
}

