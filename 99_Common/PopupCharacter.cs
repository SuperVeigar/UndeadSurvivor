using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupCharacter : Popup
    {        
        public Button select;
        public Button back;
        public Button cs;
        public Button yh;
        public Button mh;
        public Button sj;
        public Image csImage;
        public Image yhImage;
        public Image mhImage;
        public Image sjImage;
        public Text hp;
        public Text secondAttack;
        public Text secondAttackSpeed;
        public Text moveSpeed;
        public GameObject popupWeapon;

        private void Start()
        {
            Init();
            BindView();
        }

        private void Init()
        {
            Select(PlayerType.PLAYER_CS);
        }

        private void BindView()
        {
            select.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                popupWeapon.SetActive(true);
            });

            back.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });

            cs.onClick.AddListener(() =>
            {
                Select(PlayerType.PLAYER_CS);
            });

            yh.onClick.AddListener(() =>
            {
                Select(PlayerType.PLAYER_YH);
            });

            mh.onClick.AddListener(() =>
            {
                Select(PlayerType.PLAYER_MH);
            });

            sj.onClick.AddListener(() =>
            {
                Select(PlayerType.PLAYER_SJ);
            });
        }

        private void Select(PlayerType type)
        {
            GameDataService.Instance.playerType = type;

            csImage.color = PlayerType.PLAYER_CS == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            yhImage.color = PlayerType.PLAYER_YH == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            mhImage.color = PlayerType.PLAYER_MH == type ? COLOR_SELECTED : COLOR_UNSELECTED;
            sjImage.color = PlayerType.PLAYER_SJ == type ? COLOR_SELECTED : COLOR_UNSELECTED;

            switch (type)
            {
                case PlayerType.PLAYER_CS:
                    SetStar(5, 4, 2, 1);
                    break;
                case PlayerType.PLAYER_YH:
                    SetStar(2, 3, 3, 3);
                    break;
                case PlayerType.PLAYER_MH:
                    SetStar(3, 4, 2, 2);
                    break;
                case PlayerType.PLAYER_SJ:
                    SetStar(4, 3, 3, 2);
                    break;
                default:
                    break;
            }
        }

        private void SetStar(int hpCount, int secondAttackCount, int secondAttackSpeedCount, int moveSpeedCount)
        {
            hp.text = new string('★', hpCount);
            secondAttack.text = new string('★', secondAttackCount);
            secondAttackSpeed.text = new string('★', secondAttackSpeedCount);
            moveSpeed.text = new string('★', moveSpeedCount);
        }
    }
}

