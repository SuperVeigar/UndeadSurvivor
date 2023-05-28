using UnityEngine;

namespace SuperVeigar
{
    public class Player : MonoBehaviour, IDamageable
    {
        private CharacterData data;
        private Weapon weapon;
        private SecondWeapon secondWeapon;
        public PlayerSelector playerSelector;
        public WeaponSelector weaponSelector;
        public PlayerStateMachine playerStateMachine;
        public PlayerInput input;

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            playerStateMachine.UpdateState(input.MoveDirection(), input.AttackAngle(), data.GetMoveSpeed());

            weapon.Fire();
        }

        private void Init()
        {
            playerSelector.SetCharacter(GameDataService.Instance.playerType, out data);

            weaponSelector.SetWeapon(GameDataService.Instance.weaponType, GameDataService.Instance.secondWeaponType, out weapon, out secondWeapon);

            playerStateMachine.Init(gameObject, weapon.gameObject);
        }

        public void Damage(int damage)
        {

        }
    }
}

