using UnityEngine;

namespace AG3962
{
    public class EnemyFactoryBase : MonoBehaviour
    {
        public GameObject normalEnemyPrefab;
        public GameObject redEnemyPrefab;
        public float spawnSphereRadius = 5.0f;

        void Start()
        {

        }

        void Update()
        {

        }

        public virtual void SpawnRandomEnemy(Vector3 spawnPosition)
        {
            GameObject prefab = (Random.value > 0.5f) ? normalEnemyPrefab : redEnemyPrefab;
            GameObject enemy = Instantiate(prefab, spawnPosition + Random.insideUnitSphere * spawnSphereRadius, Quaternion.identity);
        }
    }
}
