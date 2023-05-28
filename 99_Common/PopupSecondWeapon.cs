using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupSecondWeapon : Popup
    {
        // Start is called before the first frame update
        public Button select;
        public Button back;
        public Button shovel;
        public Button fork;
        public Button sickle;
        public Image shovelImage;
        public Image forkImage;
        public Image sickleImage;
        public Text description;
        public Text rotationSpeed;
        public Text attackRange;
        public Text attackCount;
        public GameObject popupWeapon;

        private void Start()
        {
            Init();
            BindView();
        }

        private void Init()
        {
            Select(SecondWeaponType.Shovel);
        }

        private void BindView()
        {
            select.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                TitleService.Instance.MoveGameScene();
            });

            back.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                popupWeapon.SetActive(true);
            });

            shovel.onClick.AddListener(() =>
            {
                Select(SecondWeaponType.Shovel);
            });

            fork.onClick.AddListener(() =>
            {
                Select(SecondWeaponType.Fork);
            });

            sickle.onClick.AddListener(() =>
            {
                Select(SecondWeaponType.Sickle);
            });
        }

        private void Select(SecondWeaponType type)
        {
            GameDataService.Instance.secondWeaponType = type;

            shovelImage.color = SecondWeaponType.Shovel == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            forkImage.color = SecondWeaponType.Fork == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            sickleImage.color = SecondWeaponType.Sickle == type ? COLOR_SELECTED : COLOR_UNSELECTED;

            switch (type)
            {
                case SecondWeaponType.Shovel:
                    SetInfo("방사형 발사 공격", 1, 1, 2);
                    break;
                case SecondWeaponType.Fork:
                    SetInfo("주위 회전형 공격", 1, 1, 1);
                    break;
                case SecondWeaponType.Sickle:
                    SetInfo("임의 부메랑 공격", 0, 4, 1);
                    break;
                default:
                    break;
            }
        }

        private void SetInfo(string description, int attack, int attackSpeed, int attackRange)
        {
            this.description.text = description;
            this.rotationSpeed.text = new string('★', attack);
            this.attackRange.text = new string('★', attackSpeed);
            this.attackCount.text = new string('★', attackRange);
        }
    }
}