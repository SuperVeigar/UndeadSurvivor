using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SuperVegar
{
    public class TitleService : MonoBehaviour
    {
        public Button start;
        public Button end;

        private void Start()
        {
            BindView();
        }

        private void BindView()
        {
            start.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(Define.SCENE_GAME);
    
            });

            end.onClick.AddListener(()=>
            {
#if PLATFORM_ANDROID
                Application.Quit();
#endif
            });
        }
    }
}

