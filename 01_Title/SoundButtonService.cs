using UnityEngine;

namespace SuperVeigar
{
    public class SoundButtonService : SingletonBehaviour<SoundButtonService>
    {
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this);
        }

        public void Play()
        {
            audioSource.Play();
        }
    }
}

