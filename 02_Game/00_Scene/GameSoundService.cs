using UnityEngine;

namespace SuperVeigar
{
    public enum GameSoundType
    {
        LevelUp = 0,
        Lose,
        Win,
        Coin,
        
    }

    public class GameSoundService : SingletonBehaviour<GameSoundService>
    {
        private AudioSource audioSource;
        public AudioClip[] audioClips;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Play(GameSoundType type)
        {
            audioSource.PlayOneShot(audioClips[(int)type]);
        }
    }
}

