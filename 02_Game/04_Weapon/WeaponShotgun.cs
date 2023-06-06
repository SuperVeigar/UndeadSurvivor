using UnityEngine;

namespace SuperVeigar
{
    public class WeaponShotgun : Weapon
    {
        private const float FIRE_ANGLE = 35f;

        protected override void Init()
        {
            base.Init();

            data = new WeaponDataShotgun();
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
                Fire(FIRE_ANGLE * -1f);
                Fire(0f);
                Fire(FIRE_ANGLE);

                Reload((int)(RELOAD_TIME / (float)data.GetAttackSpeed() * 1000)).Forget();
            }
        }

        private void Fire(float angle)
        {
            isFireable = false;

            Bullet bullet = GetAvailableBullet().GetComponent<Bullet>().GetBullet();

            Quaternion rotation = firePoint.rotation;
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x , rotation.eulerAngles.y, rotation.eulerAngles.z + angle);

            bullet.Fire(firePoint.position, rotation, data.GetAttack(), (float)data.GetAttackRange() * ATTACKRANGE_TO_DURATION);

            audioSource.Play();
        }
    }
}