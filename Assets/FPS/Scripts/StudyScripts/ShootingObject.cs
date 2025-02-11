using System.Collections;
using Unity.FPS.Game;
using UnityEngine;

namespace AG3962
{
    public class ShootingObject : MonoBehaviour
    {
        [SerializeField] private GameObject[] particles;
        [SerializeField] private GameObject[] otherParticles;
        [SerializeField] private Transform objectTransform;

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (var particle in particles)
            {
                GameObject someParticle = Instantiate(particle, objectTransform.transform.position + (Vector3.up * 2.0f), Quaternion.identity);
                StartCoroutine(DestroyingParticles(someParticle));
            }

            foreach (var particle2 in otherParticles)
            {
                GameObject someParticle2 = Instantiate(particle2, objectTransform.transform.position + (Vector3.up * 2.0f), Quaternion.identity);
                StartCoroutine(DestroyingParticles(someParticle2));
            }
        }

        private IEnumerator DestroyingParticles(GameObject particle)
        {
            yield return new WaitForSeconds(5f);

            if (particle)
            {
                Destroy(particle);
            }
        }
    }
}

