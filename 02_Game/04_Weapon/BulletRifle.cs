using UnityEngine;

namespace SuperVeigar
{
    public class BulletRifle : Bullet
    {
        public override void Fire(Vector2 startPosition, Quaternion startRotation, int attack, float duration)
        {
            base.Fire(startPosition, startRotation, attack, duration);
        }

        public override Bullet GetBullet()
        {
            return this;
        }
    }
}

