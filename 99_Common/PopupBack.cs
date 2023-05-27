using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SuperVeigar
{
    public class PopupBack : MonoBehaviour
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
                SceneManager.LoadScene(Define.SCENE_TITLE);
            });

            backNo.onClick.AddListener(() =>
            {
                GameService.Instance.isPlay = true;
                gameObject.SetActive(false);
            });
        }
    }
}

