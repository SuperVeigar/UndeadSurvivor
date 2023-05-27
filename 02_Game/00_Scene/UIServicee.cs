using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class UIServicee : MonoBehaviour
    {
        public Button back;
        public GameObject popupBack;

        private void Start()
        {
            BindView();
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

