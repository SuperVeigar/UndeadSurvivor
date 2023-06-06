namespace SuperVeigar
{
    public class WeaponRifle : Weapon
    {

        protected override void Init()
        {
            base.Init();

            data = new WeaponDataRifle();
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
                FireOnShot();

                Reload((int)(RELOAD_TIME / (float)data.GetAttackSpeed() * 1000)).Forget();
            }
        }

        private void FireOnShot()
        {
            isFireable = false;

            Bullet bullet = GetAvailableBullet().GetComponent<Bullet>().GetBullet();

            bullet.Fire(firePoint.position, firePoint.rotation, data.GetAttack(), (float)data.GetAttackRange() * ATTACKRANGE_TO_DURATION);

            audioSource.Play();
        }
    }
}