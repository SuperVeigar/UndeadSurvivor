using UnityEngine;

namespace SuperVeigar
{
    public class SecondWeapon : MonoBehaviour
    {
        protected Player player;
        protected int rotationSpeed;
        protected int attackRange;
        protected int count;
        public GameObject secondWeaponPrefab;

        public virtual SecondWeapon GetSecondWeapon()
        {
            return this;
        }

        public virtual void Activate(Player player, int rotationSpeed, int attackRange, int count)
        {
            this.player = player;
            this.rotationSpeed = rotationSpeed;
            this.attackRange = attackRange;
            this.count = count;
        }
    }
}