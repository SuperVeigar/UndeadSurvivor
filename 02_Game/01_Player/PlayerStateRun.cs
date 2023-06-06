using UnityEngine;

namespace SuperVeigar
{
    public class PlayerStateRun : PlayerState
    {
        public override void Reset(Animator animator)
        {
            nextStateType = PlayerStateType.Run;
            animator.SetBool("Run", true);
        }

        public override void UpdateState(Vector2 move, float attack, GameObject player, GameObject weapon, int moveSpeed)
        {
            base.UpdateState(move, attack, player, weapon, moveSpeed);

            Move(player, move, moveSpeed);

            SetAnimationDirection(move, player);

            SetRunOrStand(move);
        }

        private void Move(GameObject player, Vector2 move, int moveSpeed)
        {
            if (rigidbody2D == null)
            {
                rigidbody2D = player.GetComponent<Rigidbody2D>();
            }

            rigidbody2D.velocity = move * (MOVE_SPEED + (float)moveSpeed * MOVE_SPEED_FACTOR);
        }

        private void SetAnimationDirection(Vector2 move, GameObject player)
        {
            if (animator == null)
            {
                animator = player.GetComponent<Animator>();
            }

            // move direction and attack direction are same direction
            if ((move.x > 0 && player.transform.localScale.x > 0) ||
            (move.x < 0 && player.transform.localScale.x < 0))
            {
                if (animator.GetFloat("Direction") < 0)
                {
                    animator.SetFloat("Direction", 1f);
                }
            }
            else
            {
                if (animator.GetFloat("Direction") > 0)
                {
                    animator.SetFloat("Direction", -1f);
                }
            }
        }

        public override bool IsNextStateSwitched()
        {
            return nextStateType != PlayerStateType.Run;
        }
    }
}
