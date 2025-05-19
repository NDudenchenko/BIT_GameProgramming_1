using System;
using System.Collections;
using UnityEngine;

namespace AG3962
{
    public class WaveSpawner : MonoBehaviour
    {
        public int enemiesPerWave = 5;
        public float timeBetweenSpawns = 0.5f;
        public float timeBetweenWaves = 20f;
        public int additionEnemyOnWave = 2;

        public float additionEnemyTime = 5.0f;

        public EnemyFactoryBase factory;

        public static event Action<int> OnWaveCompleted;

        private int currentWave = 1;

        private void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        private IEnumerator SpawnWaves()
        {
            while (true)
            {
                Debug.Log($"Wave {currentWave}");

                for (int i = 0; i < enemiesPerWave; i++)
                {
                    if (factory != null)
                    {
                        factory.SpawnRandomEnemy(transform.position);
                        yield return new WaitForSeconds(timeBetweenSpawns);
                    }
                }

                OnWaveCompleted?.Invoke(currentWave);
                currentWave++;
                enemiesPerWave += additionEnemyOnWave;
                yield return new WaitForSeconds(timeBetweenWaves + additionEnemyOnWave * additionEnemyTime);
            }
        }
    }

    //    public class WaveSpawner : MonoBehaviour
    //    {
    //        [Header("Spawner Settings")]
    //        public GameObject enemyPrefab;
    //        public int enemiesPerWave = 5;
    //        public float timeBetweenSpawns = 1f;
    //        public float timeBetweenWaves = 3f;
    //        public float spawnPositionOffset = 5f;
    //        public int additionEnemyOnWave = 2;

    //        // Delegate for custom spawn behavior
    //        public delegate void OnEnemySpawned(GameObject enemy);
    //        public OnEnemySpawned enemySpawnedCallback;

    //        // Event for wave completion
    //        public static event Action<int> OnWaveCompleted;

    //        private int currentWave = 1;

    //        // Start is called once before the first execution of Update after the MonoBehaviour is created
    //        void Start()
    //        {
    //            StartCoroutine(SpawnWaves());
    //        }

    //        // Update is called once per frame
    //        void Update()
    //        {

    //        }

    //        private IEnumerator SpawnWaves()
    //        {
    //            while (true)
    //            {
    //                Debug.Log($"Starting Wave {currentWave}");

    //                for (int i = 0; i < enemiesPerWave; i++)
    //                {
    //                    GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);

    //                    // Call it if somebody subscribed to the delegate
    //                    enemySpawnedCallback?.Invoke(enemy);

    //                    yield return new WaitForSeconds(timeBetweenSpawns);
    //                }

    //                OnWaveCompleted?.Invoke(currentWave);

    //                currentWave++;
    //                enemiesPerWave += additionEnemyOnWave;
    //                yield return new WaitForSeconds(timeBetweenWaves);
    //            }
    //        }

    //        private Vector3 GetRandomSpawnPosition()
    //        {
    //            return transform.position + new Vector3(UnityEngine.Random.Range(spawnPositionOffset * -1, spawnPositionOffset),
    //                0, UnityEngine.Random.Range(spawnPositionOffset * -1, spawnPositionOffset));
    //        }
    //    }
}
