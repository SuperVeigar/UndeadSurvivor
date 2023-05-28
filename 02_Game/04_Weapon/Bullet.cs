using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SuperVeigar
{
    public class Bullet : MonoBehaviour
    {
        private const float MOVE_SPEED = 500f;
        private int attack;
        private Rigidbody2D bulletRigidbody2D;

        public virtual void Fire(Vector2 startPosition, Quaternion startRotation, int attack, float duration)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;

            this.attack = attack;

            if (bulletRigidbody2D == null)
            {
                bulletRigidbody2D = GetComponent<Rigidbody2D>();
            }
            bulletRigidbody2D.AddForce(transform.up * MOVE_SPEED);
            
            SetActiveFalse(duration).Forget();
        }

        private async UniTaskVoid SetActiveFalse(float duration)
        {
            await UniTask.Delay((int)(duration * 1000f));

            gameObject.SetActive(false);
        }

        public virtual Bullet GetBullet()
        {
            return this;
        }
    }
}

