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

        public override bool IsNextStateSwitched()
        {
            return nextStateType != PlayerStateType.Run;
        }
    }
}
