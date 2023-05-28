using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace SuperVeigar
{
    public class TitleService : SingletonBehaviour<TitleService>
    {
        private const float TWINKEL_TIME = 0.75f;
        private readonly Vector3 TITLE_LARGE = new Vector3(1.02f, 1.02f, 1f);
        public Button start;
        public Button end;
        public GameObject popupCharacter;
        public Text creator;
        public Image black;
        public Image title;

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

            end.onClick.AddListener(() =>
            {
#if PLATFORM_ANDROID
                Application.Quit();
#endif
            });
        }

        private void ImSuperVeigar()
        {
            creator.DOColor(Color.yellow, TWINKEL_TIME).SetLoops(-1, LoopType.Yoyo);
            title.rectTransform.DOScale(TITLE_LARGE, 2f).SetEase(Ease.OutElastic).SetLoops(-1, LoopType.Yoyo);
        }

        public void MoveGameScene()
        {
            black.gameObject.SetActive(true);
            black.DOColor(Color.black, 1f).OnComplete(() =>
            {
                DOTween.KillAll();
                SceneManager.LoadScene(Define.SCENE_GAME);
            });
        }
    }
}

