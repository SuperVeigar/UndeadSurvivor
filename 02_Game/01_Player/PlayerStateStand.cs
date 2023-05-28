using UnityEngine;

namespace SuperVeigar
{
    public class PlayerStateStand : PlayerState
    {
        public override void Reset()
        {
            nextStateType = PlayerStateType.Stand;
        }

        public override void UpdateState(Vector2 move, float attack, GameObject player, GameObject weapon)
        {
            if (move.x < 0)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(move.x > 0)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }

            RotateWeapon(attack, player, weapon);
        }

        public override bool IsNextStateSwitched()
        {
            return nextStateType != PlayerStateType.Stand;
        }
    }
}

