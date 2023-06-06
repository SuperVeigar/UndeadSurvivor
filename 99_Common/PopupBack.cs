using UnityEngine.UI;

namespace SuperVeigar
{
    public class PopupBack : Popup
    {

        public Button backYes;
        public Button backNo;

        private void Start()
        {
            BindView();
        }

        private void BindView()
        {

            backYes.onClick.AddListener(() =>
            {
                GameService.Instance.MoveTitleScene();
            });

            backNo.onClick.AddListener(() =>
            {
                GameService.Instance.Resume();
                gameObject.SetActive(false);
            });
        }
    }
}

