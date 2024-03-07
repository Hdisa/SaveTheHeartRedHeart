using UnityEngine;

[CreateAssetMenu (menuName = "Hdisa Tools/Player Settings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Player Movement")]
    public float gravity = 9.8f;
    public float jumpForce = 10;
    public float speed = 10;
    
    [Header("Player Rotation")]
    public float rotationSpeed = 600;
    public float minAngle = -35;
    public float maxAngle = 89;
    
    [Header("Player Input")]
    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
}
