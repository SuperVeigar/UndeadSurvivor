using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace SuperVeigar
{
    public class LoadingSceneService : MonoBehaviour
    {
        private void Start()
        {
            CheckLoading().Forget();
        }

        private async UniTaskVoid CheckLoading()
        {
            await UniTask.WaitUntil(IsLoadAll);

            SceneManager.LoadScene(Define.SCENE_TITLE);
        }

        private bool IsLoadAll()
        {
            return (GameDataService.Instance != null &&
                SoundButtonService.Instance != null) == true;
        }
    }
}

