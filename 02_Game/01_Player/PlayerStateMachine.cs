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
        private PlayerState nextState;
        private List<PlayerState> states;
        
        public void Init()
        {
            states = new List<PlayerState>() {new PlayerStateStand(), new PlayerStateRun(), new PlayerStateDead()};
            SetState(PlayerStateType.Stand);
        }

        public void SetState(PlayerStateType stateType)
        {
            nextState = states[(int)stateType];
        }
    }
}
