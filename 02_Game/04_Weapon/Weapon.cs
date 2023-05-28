using UnityEngine;

namespace SuperVeigar
{
    public class Weapon : MonoBehaviour
    {
        public virtual Weapon GetWeapon()
        {
            return this;
        }
    }
}

