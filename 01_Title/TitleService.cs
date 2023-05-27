using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace SuperVeigar
{
    public class TitleService : SingletonBehaviour<TitleService>
    {
        private const float TWINKEL_TIME = 0.75f;
        public Button start;
        public Button end;
        public GameObject popupCharacter;
        public Text creator;

        private void Start()
        {
            BindView();
            ImSuperVeigar();
        }

        private void BindView()
        {
            start.onClick.AddListener(() =>
            {
                popupCharacter.SetActive(true);
            });

            end.onClick.AddListener(()=>
            {
#if PLATFORM_ANDROID
                Application.Quit();
#endif
            });
        }

        private void ImSuperVeigar()
        {
            creator.DOColor(Color.yellow, TWINKEL_TIME).SetLoops(-1, LoopType.Yoyo);
        }

        public void MoveGameScene()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(Define.SCENE_GAME);
        }
    }
}

