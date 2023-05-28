using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SuperVeigar
{
    public class WeaponDoubleBarrel : Weapon
    {
        private const float FIRE_POINT_Y = 0.2f;
        private const int SECOND_FIRE_DELAY = 300;
        
        protected override void Init()
        {
            base.Init();

            data = new WeaponDataDoubleBarrel();
            data.Init();
        }

        public override Weapon GetWeapon()
        {
            return this;
        }

        public override void Fire()
        {
            if (isFireable == true)
            {
                Fire(0).Forget();
                Fire(SECOND_FIRE_DELAY).Forget();
                Reload((int)(RELOAD_TIME / (float)data.GetAttackSpeed() * 1000)).Forget();
            }
        }

        private async UniTaskVoid Fire(int delay)
        {
            isFireable = false;

            await UniTask.Delay(delay);

            Bullet bullet = GetAvailableBullet().GetComponent<Bullet>().GetBullet();

            Vector3 position = firePoint.position + Vector3.up * FIRE_POINT_Y;

            bullet.Fire(position, firePoint.rotation, data.GetAttack(), (float)data.GetAttackRange() * ATTACKRANGE_TO_DURATION);

            bullet = GetAvailableBullet().GetComponent<Bullet>().GetBullet();

            position = firePoint.position - Vector3.up * FIRE_POINT_Y;

            bullet.Fire(firePoint.position, firePoint.rotation, data.GetAttack(), (float)data.GetAttackRange() * ATTACKRANGE_TO_DURATION);
        }
    }
}

