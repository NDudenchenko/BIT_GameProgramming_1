using UnityEngine;

namespace AG3962
{
    // Using Event binding
    public class WaveUI : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        private void OnEnable()
        {
            WaveSpawner.OnWaveCompleted += ShowWaveCompleteMessage;
        }

        private void OnDisable()
        {
            WaveSpawner.OnWaveCompleted -= ShowWaveCompleteMessage;
        }

        private void ShowWaveCompleteMessage(int waveNumber)
        {
            Debug.Log($"Wave {waveNumber} completed!");
        }
    }
}
