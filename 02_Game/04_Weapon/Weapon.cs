using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SuperVeigar
{
    public class Weapon : MonoBehaviour
    {
        protected const float ATTACKRANGE_TO_DURATION = 0.15f;
        protected const float RELOAD_TIME = 3f;
        public GameObject bulletPrefab;
        private List<GameObject> bullets;
        public Transform firePoint;
        public Transform bulletParent;
        protected WeaponData data;
        protected bool isFireable;

        private void Start()
        {
            Init();
            Reset();
        }

        protected virtual void Init()
        {
            bullets = new List<GameObject>();
        }

        public virtual void Reset()
        {
            isFireable = true;
        }

        public virtual Weapon GetWeapon()
        {
            return this;
        }

        public virtual void Fire()
        {

        }

        protected virtual async UniTaskVoid Reload(int delay)
        {
            await UniTask.Delay(delay);

            isFireable = true;
        }

        protected GameObject GetAvailableBullet()
        {
            if (bullets.Count <= 0)
            {
                bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bulletParent));

                return bullets[0];
            }
            else
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].activeInHierarchy == false)
                    {
                        bullets[i].gameObject.SetActive(true);
                        return bullets[i];
                    }
                }

                bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bulletParent));

                return bullets[bullets.Count - 1];
            }
        }
    }
}

