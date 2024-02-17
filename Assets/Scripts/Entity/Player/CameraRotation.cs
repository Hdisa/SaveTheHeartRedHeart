using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]private PlayerSettings playerSettings;
    [SerializeField]private Transform cameraAxisTransform;

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + playerSettings.rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0);

        var newAngleX = cameraAxisTransform.localEulerAngles.x - playerSettings.rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if (newAngleX > 180) newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, playerSettings.minAngle, playerSettings.maxAngle);
        cameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
