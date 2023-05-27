namespace SuperVeigar
{
    public class CharacterData
    {
        protected int maxHP;
        protected int currentHP;
        protected int attack;
        protected int attackSpeed;
        protected int secondAttack;
        protected int secondAttackSpeed;
        protected int moveSpeed;
        private CharacterDataDecorator decorator;
        
        public virtual void Init()
        {
            decorator = new CharacterDataDecorator();
            
            Reset();
            ResetCurrentHP();
        }

        public virtual void Reset()
        {
            decorator.Reset();
        }

        public int GetMaxHP()
        {
            return maxHP + decorator.maxHP;
        }

        public int GetCurrentHP() 
        {
            return currentHP;
        }

        public void AddCurrentHP(int hp)
        {
            currentHP += hp;

            if (hp < 0)
            {
                hp = 0;
            }
            else if (hp > GetMaxHP())
            {
                ResetCurrentHP();
            }
        }

        public void ResetCurrentHP()
        {
            currentHP = GetMaxHP();
        }

        public int GetAttack()
        {
            return attack + decorator.attack;
        }

        public void AddAttack(int attack)
        {
            decorator.attack += attack;
        }

        public int GetAttackSpeed()
        {
            return attackSpeed + decorator.attackSpeed;
        }

        public void AddAttackSpeed(int speed)
        {
            decorator.attackSpeed += speed;
        }

        public int GetSecondAttack()
        {
            return secondAttack + decorator.secondAttack;
        }

        public void AddSecondAttack(int attack)
        {
            decorator.secondAttack += attack;
        }

        public int GetSecondAttackSpeed()
        {
            return secondAttackSpeed + decorator.secondAttackSpeed;
        }

        public void AddSecondAttackSpeed(int speed)
        {
            decorator.secondAttackSpeed += speed;
        }

        public int GetMoveSpeed()
        {
            return moveSpeed + decorator.moveSpeed;
        }

        public void AddMoveSpeed(int speed)
        {
            decorator.moveSpeed += speed;
        }
    }

    public class CharacterDataDecorator
    {
        public int maxHP;
        public int attack;
        public int attackSpeed;
        public int secondAttack;
        public int secondAttackSpeed;
        public int moveSpeed;

        public void Reset()
        {
            maxHP = 0;
            attack = 0;
            attackSpeed = 0;
            secondAttack = 0;
            secondAttackSpeed = 0;
            moveSpeed = 0;
        }
    }

    public class CharacterDataCS : CharacterData
    {
        public override void Reset()
        {
            base.Reset();

            maxHP = 50;
            attack = 0;
            attackSpeed = 0;
            secondAttack = 4;
            secondAttackSpeed = 2;
            moveSpeed = 1;
        }
    }

    public class CharacterDataYH : CharacterData
    {
        public override void Reset()
        {
            base.Reset();

            maxHP = 20;
            attack = 0;
            attackSpeed = 0;
            secondAttack = 3;
            secondAttackSpeed = 3;
            moveSpeed = 3;
        }
    }

    public class CharacterDataMH : CharacterData
    {
        public override void Reset()
        {
            base.Reset();

            maxHP = 30;
            attack = 0;
            attackSpeed = 0;
            secondAttack = 4;
            secondAttackSpeed = 2;
            moveSpeed = 2;
        }
    }

    public class CharacterDataSJ : CharacterData
    {
        public override void Reset()
        {
            base.Reset();

            maxHP = 40;
            attack = 0;
            attackSpeed = 0;
            secondAttack = 3;
            secondAttackSpeed = 3;
            moveSpeed = 2;
        }
    }
}