using JetBrains.Annotations;
using UnityEngine;

namespace AG3962
{
    public class ShootingTarget : MonoBehaviour
    {
        public Transform targetTransform;
        public GameObject targetObject;

        [SerializeField] private Transform[] targetEndPoints;
        [SerializeField] private Material[] targetMaterials;


        public float speed = 1.0f;
        private int currentEndPointIndex = 0;

        void Start()
        {

        }

        void Update()
        {
            MoveTarget();
        }

        void MoveTarget()
        {
            var step = speed * Time.deltaTime;
            targetTransform.position = Vector3.MoveTowards(targetTransform.position, targetEndPoints[currentEndPointIndex].position, step);

            if (Vector3.Distance(targetTransform.position, targetEndPoints[currentEndPointIndex].position) < 0.001f)
            {
                SwapEndPointTarget();
            }
        }
        void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;

            int materialIndex = Random.Range(0, targetMaterials.Length);
            ChangeSphereMaterial(targetMaterials[materialIndex]);
        }

        void ChangeSphereMaterial(Material targetMat)
        {
            targetObject.GetComponent<MeshRenderer>().material = targetMat;
        }
    }
}


