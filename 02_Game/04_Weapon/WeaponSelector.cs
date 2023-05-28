using UnityEngine;

namespace SuperVeigar
{
    public enum WeaponType
    {
        DoubleBarrel = 0,
        Rifle,
        Shotgun,
    }

    public enum SecondWeaponType
    {
        Shovel = 0,
        Fork,
        Sickle,
    }

    public class WeaponSelector : MonoBehaviour
    {
        public GameObject[] weapons;
        public GameObject[] secondWeapons;

        public void SetWeapon(WeaponType weaponType, SecondWeaponType secondWeaponType, out Weapon weapon, out SecondWeapon secondWeapon)
        {
            weapons[(int)WeaponType.DoubleBarrel].SetActive(weaponType == WeaponType.DoubleBarrel);
            weapons[(int)WeaponType.Rifle].SetActive(weaponType == WeaponType.Rifle);
            weapons[(int)WeaponType.Shotgun].SetActive(weaponType == WeaponType.Shotgun);

            weapon = weapons[(int)weaponType].GetComponent<Weapon>().GetWeapon();

            secondWeapons[(int)SecondWeaponType.Shovel].SetActive(secondWeaponType == SecondWeaponType.Shovel);
            secondWeapons[(int)SecondWeaponType.Fork].SetActive(secondWeaponType == SecondWeaponType.Fork);
            secondWeapons[(int)SecondWeaponType.Sickle].SetActive(secondWeaponType == SecondWeaponType.Sickle);
            
            secondWeapon = secondWeapons[(int)secondWeaponType].GetComponent<SecondWeapon>().GetSecondWeapon();
        }
    }
}

