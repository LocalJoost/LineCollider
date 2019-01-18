using HoloToolkitExtensions.Utilities;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public void SetPoints(Vector3[] points)
    {
        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length;
        for (var i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
        }
        
        var colliderDrawer = GetComponent<LineColliderDrawer>();
        if (colliderDrawer != null)
        {
            colliderDrawer.AddColliderToLine(lineRenderer);
        }
    }
}
