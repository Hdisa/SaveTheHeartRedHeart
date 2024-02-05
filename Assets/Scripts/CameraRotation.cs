using UnityEngine;
using UnityEngine.Serialization;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]private float rotationSpeed;
    [SerializeField]private Transform cameraAxisTransform;
    [SerializeField]private float minAngle;
    [SerializeField]private float maxAngle;

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0);

        var newAngleX = cameraAxisTransform.localEulerAngles.x - rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if (newAngleX > 180) newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        cameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
