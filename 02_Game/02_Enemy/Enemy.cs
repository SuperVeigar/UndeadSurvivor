using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;

namespace SuperVeigar
{
    public enum EnemyType
    {
        Enemy0 = 0,
        Enemy1,
        Enemy2,
        Enemy3,
        Boss
    }

    public enum EnemyState
    {
        Run = 0,
        Hit,
        Dead
    }

    public enum EnemyAudio
    {
        Damaged = 0,
        Dead
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        private const float MOVE_SPEED = 0.5f;
        private const float MOVE_SPEED_FACTOR = 0.5f;
        private const int HIT_DURATION = 200;
        public EnemyType type;
        private EnemyData data;
        private int currentHP;
        private EnemyState state;
        private Animator animator;
        private Rigidbody2D enemyRigidbody2D;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;
        private Action OnDead;
        public AudioClip[] audioClips;
        private AudioSource audioSource;

        public void Init(EnemyData data, Action OnDead)
        {
            this.data = data;
            this.OnDead = OnDead;

            animator = GetComponent<Animator>();
            enemyRigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            audioSource = GetComponent<AudioSource>();
        }

        public void Reset()
        {
            currentHP = data.maxHP;

            state = EnemyState.Run;

            animator.SetBool("Dead", false);

            boxCollider2D.enabled = true;

            spriteRenderer.color = Color.white;
        }

        // Managed by enemyspawner
        public void Move(Transform target)
        {
            if (state == EnemyState.Run ||
            state == EnemyState.Hit)
            {
                enemyRigidbody2D.velocity = (target.position - transform.position).normalized * (MOVE_SPEED + (float)data.moveSpeed * MOVE_SPEED_FACTOR);

                SetFlip();
            }
        }

        private void SetFlip()
        {
            if (enemyRigidbody2D.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (enemyRigidbody2D.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        public void Damage(int damage)
        {
            if (state == EnemyState.Run)
            {
                currentHP -= damage;
                
                if (currentHP > 0)
                {
                    audioSource.PlayOneShot(audioClips[(int)EnemyAudio.Damaged]);
                    SetRunState().Forget();
                }
                else
                {
                    audioSource.PlayOneShot(audioClips[(int)EnemyAudio.Dead]);
                    SetDeadState();
                }
            }
        }

        private async UniTaskVoid SetRunState()
        {
            state = EnemyState.Hit;

            animator.SetTrigger("Hit");

            await UniTask.Delay(HIT_DURATION);

            state = EnemyState.Run;
        }

        private void SetDeadState()
        {
            state = EnemyState.Dead;

            animator.SetBool("Dead", true);

            enemyRigidbody2D.velocity = Vector2.zero;

            boxCollider2D.enabled = false;

            OnDead?.Invoke();

            spriteRenderer.DOColor(Color.clear, 1f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });

            SpawnCoin(type);
        }

        private void SpawnCoin(EnemyType type)
        {
            switch (type)
            {
                default:
                    CoinSpawnService.Instance.SpawnCoin(CoinType.Normal, transform.position);
                    break; 
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                collision.gameObject.GetComponent<IDamageable>().Damage(data.attack);

                SetDeadState();
            }
        }
    }
}

