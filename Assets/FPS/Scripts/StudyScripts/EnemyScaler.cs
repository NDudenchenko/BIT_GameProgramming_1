using UnityEngine;

namespace AG3962
{
    public class EnemyScaler : MonoBehaviour
    {
        public WaveSpawner spawner;

        void Start()
        {
            //spawner.enemySpawnedCallback += MakeEnemyStronger;
        }

        void Update()
        {

        }

        private void MakeEnemyStronger(GameObject enemy)
        {
            enemy.transform.localScale *= 1.5f;
        }
    }
}

