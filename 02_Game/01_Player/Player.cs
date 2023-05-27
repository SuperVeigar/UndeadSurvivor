using UnityEngine;

namespace SuperVeigar
{
    public class Player : MonoBehaviour
    {
        private CharacterData data;
        public PlayerSelector playerSelector;
        public PlayerStateMachine playerStateMachine;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            playerStateMachine.Init();
            playerSelector.SetCharacter(GameDataService.Instance.playerType);
            data = playerSelector.GetCharacterData(GameDataService.Instance.playerType);
        }
    }
}

