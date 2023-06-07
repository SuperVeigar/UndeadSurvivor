using UnityEngine;

namespace SuperVeigar
{
    public class TestService : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.LevelUp();
            }
        }
    }
}

