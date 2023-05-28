using UnityEngine;

namespace SuperVeigar
{
    public class PlayerInput : MonoBehaviour
    {
        public bl_Joystick left;
        public bl_Joystick right;
        private Vector2 moveDirection = Vector2.zero;
        private Vector3 attackDirection = Vector2.zero;
        private float attackAngle = 0f;

        public Vector2 MoveDirection()
        {
            moveDirection.x = left.Horizontal;
            moveDirection.y = left.Vertical;
            return moveDirection;
        }

        // Vector3.right 기준의 각도
        public float AttackAngle()
        {
            attackDirection.x = right.Horizontal;
            attackDirection.y = right.Vertical;

            return Quaternion.FromToRotation(Vector3.right, attackDirection - Vector3.right).eulerAngles.z;
        }
    }
}

