using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

namespace SuperVeigar
{
    public class GameService : SingletonBehaviour<GameService>
    {
        private bool isPlay = false;
        public event Action OnReset;
        public event Action OnPause;
        public event Action OnResume;

        private void Start()
        {
            Init();
            Reset();
            Pause();
        }

        private void Init()
        {
            OnPause += () => GameService.Instance.isPlay = false;

            OnResume += () => GameService.Instance.isPlay = true;;
        }

        public void Reset()
        {
            OnReset?.Invoke();
        }        

        public void Pause()
        {
            OnPause?.Invoke();            
        }

        public void Resume()
        {
            OnResume?.Invoke();            
        }

        public void PlayGame()
        {
            Reset();
            Resume();
        }

        public void GameOver()
        {
            Pause();
        }

        public void MoveTitleScene()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(Define.SCENE_TITLE);
        }

        public bool IsPlay()
        {
            return isPlay;
        }
    }
}

