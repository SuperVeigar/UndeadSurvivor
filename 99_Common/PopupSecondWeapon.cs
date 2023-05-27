using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupSecondWeapon : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button select;
        public Button back;
        public GameObject popupWeapon;

        private void Start()
        {
            BindView();
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
        }
    }
}