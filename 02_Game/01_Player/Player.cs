using UnityEngine;

namespace SuperVeigar
{
    public enum PlayerAudio
    {
        Damaged = 0,
    }
    public class Player : MonoBehaviour, IDamageable
    {
        private CharacterData data;
        private Weapon weapon;
        private SecondWeapon secondWeapon;
        public PlayerSelector playerSelector;
        public WeaponSelector weaponSelector;
        public PlayerStateMachine playerStateMachine;
        public PlayerInput input;
        public AudioClip[] audioClips;
        private AudioSource audioSource;

        private void Start()
        {
            Init();
            Reset();
        }

        private void Update()
        {
            if (GameService.Instance.IsPlay() == true)
            {
                playerStateMachine.UpdateState(input.MoveDirection(), input.AttackAngle(), data.GetMoveSpeed());

                weapon.Fire();

                UpdateHPPosition();
            }            
        }

        private void Init()
        {
            audioSource = GetComponent<AudioSource>();

            playerSelector.SetCharacter(GameDataService.Instance.playerType, out data);

            weaponSelector.SetWeapon(GameDataService.Instance.weaponType, GameDataService.Instance.secondWeaponType, out weapon, out secondWeapon);

            playerStateMachine.Init(gameObject, weapon.gameObject);
            
            UpdateHPPosition();
        }

        private void Reset()
        {
            weapon.gameObject.SetActive(true);
            secondWeapon.gameObject.SetActive(true);

            data.Reset();
            data.ResetCurrentHP();
        }

        public void Damage(int damage)
        {
            audioSource.PlayOneShot(audioClips[(int)PlayerAudio.Damaged]);

            data.AddCurrentHP(damage * -1);            

            if (data.GetCurrentHP() <= 0)
            {
                SetDead();
            }
        }

        private void UpdateHPPosition()
        {
            UIService.Instance.UpdateHPPosition(transform.position);
        }

        private void SetDead()
        {
            playerStateMachine.SetState(PlayerStateType.Dead);

            weapon.gameObject.SetActive(false);
            secondWeapon.gameObject.SetActive(false);

            GameService.Instance.GameOver();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Item") == true)
            {
                collider.gameObject.GetComponent<ICollectable>().Collect(data);
            }
        }
    }
}

