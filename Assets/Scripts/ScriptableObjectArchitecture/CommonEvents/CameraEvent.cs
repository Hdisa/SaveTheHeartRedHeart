using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/CameraEvent")]
public class CameraEvent : GenericEvent<Camera> { }
}