using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SuperVeigar
{
    public enum PopupType
    {
        PopupBack,
        PopupLevelUp,
    }

    public class UIService : SingletonBehaviour<UIService>
    {
        private readonly Vector3 HP_POSITION_FROM_PLAYER = new Vector3(0, -60, 0);
        public Button back;
        public GameObject popupBack;
        public GameObject popupLevelUp;
        public Image black;
        public Text time;
        public Image hp;
        public Image hpBar;
        public Text enemies;
        public Image exp;
        public Text level;

        private void Start()
        {
            Init();
            BindView();
        }

        private void Init()
        {
            black.gameObject.SetActive(true);
            black.DOColor(Color.clear, 0.5f).OnComplete(() =>
            {
                black.gameObject.SetActive(false);

                GameService.Instance.PlayGame();
            });
        }

        private void FixedUpdate()
        {
            SetTime(TimerService.Instance.GetTime());
        }

        private void BindView()
        {
            back.onClick.AddListener(() =>
            {
                SetActivePopupBack(PopupType.PopupBack, true);
            });
        }

        public void SetActivePopupBack(PopupType type, bool isActive)
        {
            if (isActive == true)
            {
                GameService.Instance.Pause();
            }
            else
            {
                GameService.Instance.Resume();
            }

            switch (type)
            {
                case PopupType.PopupBack:
                    popupBack.gameObject.SetActive(isActive);
                    break;
                case PopupType.PopupLevelUp:
                    popupLevelUp.gameObject.SetActive(isActive);
                    break;
            }
        }

        public void SetTime(float time)
        {
            this.time.text = string.Format("{0:D2}:{1:D2}",((int)time / 60), ((int)time % 60));
        }

        public void UpdateHPPosition(Vector3 position)
        {
            hp.transform.position = Camera.main.WorldToScreenPoint(position) + HP_POSITION_FROM_PLAYER;
        }

        public void UpdateHP(float value)
        {
            hpBar.fillAmount = value;
        }

        public void UpdateEnemyCount(int count)
        {
            enemies.text = count.ToString();
        }

        public void UpdateEXP(int currentExp, int maxExp)
        {
            exp.fillAmount = (float)currentExp / (float)maxExp;
        }

        public void UpdateLevel(int level)
        {
            this.level.text = "LV. " + level.ToString();            
        }
    }
}

