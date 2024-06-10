using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private Transform player;
    //[SerializeField] private Transform playerHead;
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float cameraSensitivity = 10f;
    [SerializeField] private float verticalMinClamp = -30f;
    [SerializeField] private float verticalMaxClamp = 30f;

    private Vector2 _input = Vector2.zero;
    private float _verticalRotation = 0f;

    private void OnEnable()
    {
        //_verticalRotation = playerSpine.eulerAngles.x;
        playerController.OnMouseInput += SetInput;
        playerController.OnAimInput += SwitchCameraOnAim;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        playerController.OnMouseInput -= SetInput;
        playerController.OnAimInput -= SwitchCameraOnAim;
    }

    // We update the camera on LateUpdate to allow for all physics calculations to happen beforehand
    private void Update()
    {
        RotateHorizontally();
        RotateVertically();
    }

    public void SetInput(Vector2 input)
    {
        _input = input;
    }

    public void SwitchCameraOnAim(bool isAiming)
    {
        aimCamera.gameObject.SetActive(isAiming);
    }

    private void RotateHorizontally()
    {
        if (_input.x == 0f)
            return;

        float horizontalRotation = SmoothValue(_input.x);

        Vector3 targetRotation = player.eulerAngles;
        targetRotation.y += horizontalRotation;

        player.eulerAngles = targetRotation;
    }

    private float SmoothValue(float value)
    {
        return value * cameraSensitivity * Time.deltaTime;
    }

    private void RotateVertically()
    {
        if (_input.y == 0f)
            return;

        Vector3 currentRotation = cameraTarget.eulerAngles;
        _verticalRotation += SmoothValue(_input.y);

        _verticalRotation = Mathf.Clamp(_verticalRotation, verticalMinClamp, verticalMaxClamp);
        currentRotation.x = -_verticalRotation;

        cameraTarget.eulerAngles = currentRotation;
        // We need to figure out how to fix the animation overwriting the rotation
        //playerHead.eulerAngles = currentRotation;
    }
}
