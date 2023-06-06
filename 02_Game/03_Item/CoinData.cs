using UnityEngine;

namespace SuperVeigar
{
    [CreateAssetMenu(fileName = "Coin Data", menuName = "Scriptable object/Coin Data")]
    public class CoinData : ScriptableObject
    {
        [SerializeField]
        public int exp;
        [SerializeField]
        public CoinType type;
    }
}
