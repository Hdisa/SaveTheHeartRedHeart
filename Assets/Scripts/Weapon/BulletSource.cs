using UnityEngine;

public class BulletSource : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private Camera cameraLink;
    [SerializeField] private float targetInSkyDistance;

    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            targetPoint.position = hit.point;
        else
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        transform.LookAt(targetPoint.position);
    }
}
