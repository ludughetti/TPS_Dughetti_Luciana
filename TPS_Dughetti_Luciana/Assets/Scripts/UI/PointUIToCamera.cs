using UnityEngine;

public class PointUIToCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    void Update()
    {
        if (cameraTarget != null)
            transform.LookAt(cameraTarget);
    }
}
