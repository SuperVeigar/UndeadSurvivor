using UnityEngine;
using System.Collections.Generic;

namespace SuperVeigar
{
    public enum PlayerStateType
    {
        Stand = 0,
        Run,
        Dead,
    }
    public class PlayerStateMachine : MonoBehaviour
    {    
        private PlayerState currentState;
        private List<PlayerState> states;
        private GameObject player;
        private GameObject weapon;
        private Animator animator;
        
        public void Init(GameObject player, GameObject weapon)
        {
            animator = GetComponent<Animator>();
            this.player = player;
            this.weapon = weapon;

            states = new List<PlayerState>() {new PlayerStateStand(), new PlayerStateRun(), new PlayerStateDead()};
            SetState(PlayerStateType.Stand);
        }

        public void UpdateState(Vector2 move, float attack, int moveSpeed)
        {
            currentState.UpdateState(move, attack, player, weapon, moveSpeed);

            if (currentState.IsNextStateSwitched() == true)
            {
                SetState(currentState.nextStateType);
            }
        }

        public void SetState(PlayerStateType stateType)
        {
            currentState = states[(int)stateType];
            currentState.Reset(animator);
        }
    }
}
