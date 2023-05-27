using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupWeapon : MonoBehaviour
    {
        public Button select;
        public Button back;
        public GameObject popupCharacter;
        public GameObject popupSecondWeapon;

        private void Start()
        {
            BindView();
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
        }
    }
}
