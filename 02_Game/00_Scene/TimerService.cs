using UnityEngine;

namespace SuperVeigar
{
    public class TimerService : SingletonBehaviour<TimerService>
    {
        private float time;
        private bool isUpdate;

        private void Start()
        {
            Init();
            RegisterEvent();
        }

        private void Update()
        {
            if (isUpdate == true)
            {
                time += Time.deltaTime;
            }
        }

        private void Init()
        {
            StopTime();
            ResetTime();
        }

        private void RegisterEvent()
        {
            GameService.Instance.OnReset += () => ResetTime();

            GameService.Instance.OnPause += () => StopTime();
            
            GameService.Instance.OnResume += () => StartTime();
        }

        public void StartTime()
        {
            isUpdate = true;
        }

        public void ResetTime()
        {
            time = 0f;
        }

        public void StopTime()
        {
            isUpdate = false;
        }

        public float GetTime()
        {
            return time;
        }
    }
}
