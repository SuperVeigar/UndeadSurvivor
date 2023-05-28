namespace SuperVeigar
{
    public class WeaponData
    {
        protected int attack;
        protected int attackSpeed;
        protected int attackRange;
        private WeaponDataDecorator decorator;

        public virtual void Init()
        {
            decorator = new WeaponDataDecorator();
            Reset();
        }

        public int GetAttack()
        {
            return attack + decorator.attack;
        }

        public int GetAttackSpeed()
        {
            return attackSpeed + decorator.attackSpeed;
        }

        public int GetAttackRange()
        {
            return attackRange + decorator.attackRange;
        }

        public virtual void Reset()
        {
            decorator.Reset();
        }
    }

    public class WeaponDataDoubleBarrel : WeaponData
    {
        public override void Reset()
        {
            base.Reset();

            attack = 4;
            attackSpeed = 1;
            attackRange = 1;
        }
    }

    public class WeaponDataRifle : WeaponData
    {
        public override void Reset()
        {
            base.Reset();

            attack = 2;
            attackSpeed = 4;
            attackRange = 3;
        }
    }

    public class WeaponDataShotgun : WeaponData
    {
        public override void Reset()
        {
            base.Reset();

            attack = 5;
            attackSpeed = 2;
            attackRange = 1;
        }
    }

    public class WeaponDataDecorator
    {
        public int attack;
        public int attackSpeed;
        public int attackRange;

        public void Reset()
        {
            attack = 0;
            attackSpeed = 0;
            attackRange = 0;
        }
    }
}