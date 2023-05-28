using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupWeapon : Popup
    {
        public Button select;
        public Button back;
        public Button doubleBarrel;
        public Button rifle;
        public Button shotGun;
        public Image doubleBarrelImage;
        public Image rifleImage;
        public Image shotGunImage;
        public Text description;
        public Text attack;
        public Text attackSpeed;
        public Text attackRange;
        public GameObject popupCharacter;
        public GameObject popupSecondWeapon;

        private void Start()
        {
            Init();
            BindView();
        }

        private void Init()
        {
            Select(WeaponType.DoubleBarrel);
        }

        private void BindView()
        {
            select.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                popupSecondWeapon.SetActive(true);
            });

            back.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                popupCharacter.SetActive(true);
            });

            doubleBarrel.onClick.AddListener(() =>
            {
                Select(WeaponType.DoubleBarrel);
            });

            rifle.onClick.AddListener(() =>
            {
                Select(WeaponType.Rifle);
            });

            shotGun.onClick.AddListener(() =>
            {
                Select(WeaponType.Shotgun);
            });
        }

        private void Select(WeaponType type)
        {
            GameDataService.Instance.weaponType = type;

            doubleBarrelImage.color = WeaponType.DoubleBarrel == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            rifleImage.color = WeaponType.Rifle == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            shotGunImage.color = WeaponType.Shotgun == type ? COLOR_SELECTED : COLOR_UNSELECTED;

            switch (type)
            {
                case WeaponType.DoubleBarrel:
                    SetInfo("2발 탄환 빠르게 연사", 4, 1, 1);
                    break;
                case WeaponType.Rifle:
                    SetInfo("1발 탄환 연사", 2, 4, 3);
                    break;
                case WeaponType.Shotgun:
                    SetInfo("3발 탄환 발사", 5, 2, 1);
                    break;
                default:
                    break;
            }
        }

        private void SetInfo(string description, int attack, int attackSpeed, int attackRange)
        {
            this.description.text = description;
            this.attack.text = new string('★', attack);
            this.attackSpeed.text = new string('★', attackSpeed);
            this.attackRange.text = new string('★', attackRange);
        }
    }
}
