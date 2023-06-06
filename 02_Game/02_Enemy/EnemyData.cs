using UnityEngine;

namespace SuperVeigar
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable object/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        public int  maxHP;
        [SerializeField]
        public int  attack;
        [SerializeField]
        public int  moveSpeed;
    }
}
