using UnityEngine;

namespace HoloToolkitExtensions.Utilities
{
    /// <summary>
    /// Adds colliders to a line
    /// Inspired by https://answers.unity.com/questions/470943/collider-for-line-renderer.html
    /// </summary>
    public class LineColliderDrawer : MonoBehaviour
    {
        private const string LineColliderName = "LineCollider";

        /// <summary>
        /// Add collider(s) to a line
        /// </summary>
        /// <param name="lineRenderer"></param>
        public void AddColliderToLine(LineRenderer lineRenderer)
        {
            RemoveExistingColliders(lineRenderer);

            for (var p = 0; p < lineRenderer.positionCount; p++)
            {
                if (p < lineRenderer.positionCount - 1)
                {
                    AddColliderToLine(lineRenderer, lineRenderer.GetPosition(p), 
                        lineRenderer.GetPosition(p + 1));
                }
            }
        }

        /// <summary>
        /// Remove potentially existing colliders created by this behavior
        /// </summary>
        /// <param name="lineRenderer"></param>
        private void RemoveExistingColliders(LineRenderer lineRenderer)
        {
            for (var i = lineRenderer.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                var child = lineRenderer.gameObject.transform.GetChild(i);
                if (child.name == LineColliderName)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        /// <summary>
        /// Add a collider from start to endpoint from start to end
        /// </summary>
        /// <param name="lineRenderer"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        private  void AddColliderToLine( LineRenderer lineRenderer, Vector3 startPoint, Vector3 endPoint)
        {
            var lineCollider = new GameObject(LineColliderName).AddComponent<CapsuleCollider>();
            //set the collider as a child of your line
            lineCollider.transform.parent = lineRenderer.transform;
            //set the desired width, we are assuming constant width here
            lineCollider.radius = lineRenderer.endWidth;
            var midPoint = (startPoint + endPoint) / 2f;
            // move the created collider to the midPoint
            lineCollider.transform.position = midPoint;

            //rotate to the right angle. The x angle needs to have added 90 degrees
            lineCollider.transform.LookAt(endPoint);
            var rotationEulerAngles = lineCollider.transform.rotation.eulerAngles;
            lineCollider.transform.rotation =
                Quaternion.Euler(rotationEulerAngles.x + 90f, rotationEulerAngles.y, rotationEulerAngles.z);

            lineCollider.height = Vector3.Distance(startPoint, endPoint);
        }
    }
}
