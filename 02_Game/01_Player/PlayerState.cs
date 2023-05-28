using UnityEngine;

namespace SuperVeigar
{
    public class PlayerState
    {
        protected PlayerStateType nextStateType;

        public virtual void Reset()
        {

        }

        public virtual void UpdateState(Vector2 move, float attack, GameObject player, GameObject weapon)
        {

        }

        protected void RotateWeapon(float attack, GameObject player, GameObject weapon)
        {
            if (attack == 0f)
            {
                return;
            }
            // 좌측 보고 있는 상황
            else if (player.transform.localScale.x < 0)
            {
                // 상단
                if (0f <= attack && attack < 180f)
                {
                    float convertedAttack = 180f - attack;
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(convertedAttack, 0f, 90f));
                }
                // 하단
                else
                {
                    float convertedAttack = 180f - attack;
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(convertedAttack, -90f, 0f));
                }
            }
            // 우측 보고 있는 상황
            else
            {
                // 상단
                if (0f <= attack && attack < 180f)
                {
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(attack, 0f, 90f));
                }
                // 하단
                else
                {
                    weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Clamp(attack, 270f, 360f));
                }
            }
        }

        public virtual bool IsNextStateSwitched()
        {
            return false;
        }
    }
}

