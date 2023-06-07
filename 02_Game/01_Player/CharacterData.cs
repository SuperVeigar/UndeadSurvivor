using System.Collections.Generic;
using UniRx;

namespace SuperVeigar
{
    public class CharacterData
    {
        protected int maxHP;
        protected ReactiveProperty<int> currentHP;
        protected int attack;
        protected int attackSpeed;
        protected int secondAttack;
        protected int secondAttackSpeed;
        protected int moveSpeed;
        protected ReactiveProperty<int> exp;
        protected ReactiveProperty<int> level;
        private CharacterDataDecorator decorator;

        public virtual void Init()
        {
            decorator = new CharacterDataDecorator();
            currentHP = new ReactiveProperty<int>(1);
            exp = new ReactiveProperty<int>(0);
            level = new ReactiveProperty<int>(1);

            InitReactive();
            
            Reset();
            ResetCurrentHP();
        }

        public virtual void Reset()
        {
            exp.Value = 0;
            level.Value = 1;

            decorator.Reset();
        }

        private void InitReactive()
        {
            currentHP.Subscribe(hp => UIService.Instance.UpdateHP((float)GetCurrentHP() / (float)GetMaxHP()));
            
            exp.Subscribe(x => UIService.Instance.UpdateEXP(exp.Value, CharacterEXPData.expData[level.Value - 1]));
            
            level.Subscribe(lv => UIService.Instance.UpdateLevel(level.Value));
        }

        public int GetMaxHP()
        {
            return maxHP + decorator.maxHP;
        }

        public int GetCurrentHP()
        {
            return currentHP.Value;
        }

        public void AddCurrentHP(int hp)
        {
            currentHP.Value += hp;

            if (currentHP.Value < 0)
            {
                currentHP.Value = 0;
            }
            else if (currentHP.Value > GetMaxHP())
            {
                ResetCurrentHP();
            }
        }

        public void ResetCurrentHP()
        {
            currentHP.Value = GetMaxHP();
        }

        public void AddMaxHP(int hp)
        {
            currentHP.Value += hp;
            decorator.maxHP += hp;
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

        public int GetEXP()
        {
            return exp.Value;
        }

        public void AddEXP(int exp)
        {
            if (exp > 0)
            {
                this.exp.Value += exp;

                CheckLevelUp();
            }
            else
            {
                this.exp.Value = 0;
                LevelUp();
            }
        }

        private void LevelUp()
        {            
            level.Value++;
            
            GameSoundService.Instance.Play(GameSoundType.LevelUp);

            UIService.Instance.SetActivePopupBack(PopupType.PopupLevelUp, true);
        }

        public int GetLevel()
        {
            return level.Value;
        }

        private void CheckLevelUp()
        {
            while (true)
            {
                if (exp.Value >= CharacterEXPData.expData[level.Value - 1])
                {

                    exp.Value -= CharacterEXPData.expData[level.Value - 1];
                    LevelUp();
                }
                else
                {
                    break;
                }
            }
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

    public static class CharacterEXPData
    {
        public static List<int> expData;

        static CharacterEXPData()
        {
            expData = new List<int>() { 5, 15, 35, 65, 105, 155, 215, 285, 365, 455, 555, 665, 785, 915, 1055, 1205, 1365, 1535, 1715, 1905, 2105, 2315, 2535, 2765, 3005, 3255, 3515, 3785, 4065, 4355 };
        }
    }
}