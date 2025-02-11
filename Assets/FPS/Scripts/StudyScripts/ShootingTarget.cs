using JetBrains.Annotations;
using UnityEngine;

namespace AG3962
{
    public class ShootingTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;
        public Transform target;

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
            target.position = Vector3.MoveTowards(target.position, targetEndPoints[currentEndPointIndex].position, step);

            if (Vector3.Distance(target.position, targetEndPoints[currentEndPointIndex].position) < 0.001f)
            {
                SwapEndPointTarget();
            }
        }
        void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;
        }
    }
}


