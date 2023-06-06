using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace SuperVeigar
{
    public class EnemyManager : MonoBehaviour
    {
        private const float EMENY_0_START_TIME = 0f;            // sec
        private const float EMENY_1_START_TIME = 90f;            // sec
        private const float EMENY_2_START_TIME = 180f;            // sec
        private const float EMENY_3_START_TIME = 300f;            // sec
        private const float EMENY_BOSS_START_TIME = 420f;         // sec
        private const int ENEMY_TYPE_COUNT = 4;
        private const float ENEMY_COOLTIME = 1f;
        private const float ENEMY_SPAWN_COUNT_INCREASE_TIME = 10f;  // time to increase the count spawning enemies
        private const int ENEMY_SPAWN_DEFAULT_COUNT = 2;
        private const float MAP_SIZE = 50f;
        private const float ENEMY_SPAWN_RADIUS = 15f;

        public Transform player;
        public EnemyData[] data;
        public GameObject[] enemyPrefabs;
        private List<Enemy> enemies0;
        private List<Enemy> enemies1;
        private List<Enemy> enemies2;
        private List<Enemy> enemies3;
        private List<EnemyTimer> enemyTimers;
        private List<int> enemySpawnCount;
        private ReactiveProperty<int> enemyCount;

        private void Start()
        {
            InitReactive();

            InitEnemies();
            InitEnemySpawnData();

            RegisterEvent();
        }

        private void Reset()
        {
            for (int i = 0; i < ENEMY_TYPE_COUNT; i++)
            {
                enemyTimers[i].StartTimer(ENEMY_COOLTIME);

                enemySpawnCount[i] = ENEMY_SPAWN_DEFAULT_COUNT;
            }

            SetActiveEnemies(enemies0, false);
            SetActiveEnemies(enemies1, false);
            SetActiveEnemies(enemies2, false);
            SetActiveEnemies(enemies3, false);

            enemyCount.Value = 0;
        }

        private void InitEnemies()
        {
            enemies0 = new List<Enemy>();
            enemies1 = new List<Enemy>();
            enemies2 = new List<Enemy>();
            enemies3 = new List<Enemy>();
        }

        private void InitEnemySpawnData()
        {
            enemyTimers = new List<EnemyTimer>();
            enemySpawnCount = new List<int>();

            for (int i = 0; i < ENEMY_TYPE_COUNT; i++)
            {
                enemyTimers.Add(new EnemyTimer());

                enemySpawnCount.Add(ENEMY_SPAWN_DEFAULT_COUNT);
            }
        }

        private void InitReactive()
        {
            enemyCount = new ReactiveProperty<int>();
            enemyCount.Subscribe(count => UIService.Instance.UpdateEnemyCount(count));
        }

        private void RegisterEvent()
        {
            GameService.Instance.OnReset += Reset;

            EnemyTimer timer = null;
            for (int i = 0; i < ENEMY_TYPE_COUNT; i++)
            {
                timer = enemyTimers[i];

                GameService.Instance.OnPause += () => timer.Pause();

                GameService.Instance.OnResume += () => timer.Resume();
            }
        }

        private void Update()
        {
            if (GameService.Instance.IsPlay() == true)
            {
                for (int i = 0; i < ENEMY_TYPE_COUNT; i++)
                {
                    enemyTimers[i].Update();
                }
            }
        }

        private void FixedUpdate()
        {
            if (GameService.Instance.IsPlay() == true)
            {
                SpawnEnemies();

                UpdateEnemyMove();
            }

        }

        private void UpdateEnemyMove()
        {
            for (int i = 0; i < enemies0.Count; i++)
            {
                enemies0[i].Move(player);
            }
        }

        private void SpawnEnemies()
        {
            if (TimerService.Instance.GetTime() >= EMENY_0_START_TIME)
            {                
                if (enemyTimers[0].IsOverCoolTime() == true)
                {
                    for (int i = 0; i < enemySpawnCount[0]; i++)
                    {
                        Enemy enemy = GetAvailableEnemy(EnemyType.Enemy0);
                        enemy.Reset();
                        enemy.transform.position = GetRandomPosition();

                        enemyCount.Value++;
                    }
                }
            }
        }

        private Enemy GetAvailableEnemy(EnemyType type)
        {
            List<Enemy> enemies = null;

            switch (type)
            {
                case EnemyType.Enemy0:
                    enemies = enemies0;
                    break;
                case EnemyType.Enemy1:
                    break;
                case EnemyType.Enemy2:
                    break;
                case EnemyType.Enemy3:
                    break;
                case EnemyType.Boss:
                    break;
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].gameObject.activeInHierarchy == false)
                {
                    enemies[i].gameObject.SetActive(true);

                    return enemies[i];
                }
            }

            Enemy enemy = Instantiate(enemyPrefabs[(int)type], Vector3.zero, Quaternion.identity, transform).GetComponent<Enemy>();
            enemy.Init(data[(int)type], OnDead: () => enemyCount.Value--);

            enemies.Add(enemy);

            return enemy;
        }

        private Vector2 GetRandomPosition()
        {
            int randomX = Random.Range((int)MAP_SIZE * -1 , (int)MAP_SIZE);
            int randomY = Random.Range((int)MAP_SIZE * -1 , (int)MAP_SIZE);

            Vector3 direction = new Vector3(randomX, randomY, 0);
            direction.Normalize();

            Vector3 position = player.transform.position + direction * ENEMY_SPAWN_RADIUS;

            position.x = Mathf.Clamp(position.x, MAP_SIZE * -1, MAP_SIZE);
            position.y = Mathf.Clamp(position.y, MAP_SIZE * -1, MAP_SIZE);

            return position;
        }

        private void SetActiveEnemies(List<Enemy> enemies, bool isActive)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].gameObject.SetActive(isActive);
            }
        }
    }
}

