using UnityEngine;

namespace AG3962
{
    public class EnemyFactoryAdvanced : EnemyFactoryBase
    {
        public float spawnBoxDimensionX = 50.0f;
        public float spawnBoxDimensionY = 50.0f;

        void Start()
        {

        }

        void Update()
        {

        }

        public override void SpawnRandomEnemy(Vector3 spawnPosition)
        {
            GameObject prefab = (Random.value > 0.5f) ? normalEnemyPrefab : redEnemyPrefab;
            GameObject enemy = Instantiate(prefab, spawnPosition + new Vector3(spawnBoxDimensionX, 0.0f, spawnBoxDimensionY), 
                Quaternion.identity);
        }
    }
}
