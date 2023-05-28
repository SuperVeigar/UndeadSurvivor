using UnityEngine;

namespace SuperVeigar
{
    public class PlayerState
    {
        protected const float MOVE_SPEED = 0.5f;
        protected const float MOVE_SPEED_FACTOR = 0.2f;
        public PlayerStateType nextStateType;
        protected Rigidbody2D rigidbody2D;

        public virtual void Reset(Animator animator)
        {

        }

        public virtual void UpdateState(Vector2 move, float attack, GameObject player, GameObject weapon, int moveSpeed)
        {
            if (GameService.Instance.isPlay == true)
            {
                SetFlip(move, player);
                RotateWeapon(attack, player, weapon);
            }
        }

        protected void RotateWeapon(float attack, GameObject player, GameObject weapon)
        {
            // no touch
            if (attack == 0f)
            {
                weapon.transform.localEulerAngles = Vector3.zero;
            }
            // face to the left
            else if (player.transform.localScale.x < 0)
            {
                // upper
                if (0f <= attack && attack < 180f)
                {
                    float convertedAttack = 180f - attack;
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(convertedAttack, 0f, 90f));
                }
                // lower
                else
                {
                    float convertedAttack = 180f - attack;
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(convertedAttack, -90f, 0f));
                }
            }
            // face to the right
            else
            {
                // upper
                if (0f <= attack && attack < 180f)
                {
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(attack, 0f, 90f));
                }
                // lower
                else
                {
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(attack, 270f, 360f));
                }
            }
        }

        protected void SetFlip(Vector2 move, GameObject player)
        {
            if (move.x < 0)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (move.x > 0)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        public virtual bool IsNextStateSwitched()
        {
            return false;
        }

        protected void SetRunOrStand(Vector2 move)
        {
            if (move != Vector2.zero)
            {
                nextStateType = PlayerStateType.Run;
            }
            else
            {
                nextStateType = PlayerStateType.Stand;
            }
        }
    }
}

