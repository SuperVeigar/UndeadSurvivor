using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SuperVeigar
{
    public class UIServicee : MonoBehaviour
    {
        public Button back;
        public GameObject popupBack;
        public Image black;

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
            });
        }

        private void BindView()
        {
            back.onClick.AddListener(() =>
            {
                SetActivePopupBack(true);
            });
        }

        private void SetActivePopupBack(bool isActive)
        {
            GameService.Instance.isPlay = !isActive;
            popupBack.gameObject.SetActive(isActive);
        }
    }
}

