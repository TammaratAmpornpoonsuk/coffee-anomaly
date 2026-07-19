using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private int _dragMouseButton = 1; // 0 = left, 1 = right, 2 = middle
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private bool _invertTilt = false;

    [Header("Pan limits (yaw / left-right)")]
    [SerializeField] private float _minYaw = -60f;
    [SerializeField] private float _maxYaw = 60f;

    [Header("Tilt limits (pitch / up-down)")]
    [SerializeField] private float _minPitch = -30f;
    [SerializeField] private float _maxPitch = 45f;

    [Header("Movement")]
    [Tooltip("How quickly the camera eases toward the target angle. 0 = instant.")]
    [SerializeField] private float _smoothing = 10f;

    // The mounted camera angle.
    private Quaternion _homeRotation;

    // Current offset angles from home, in degrees.
    private float _yaw;
    private float _pitch;

    private void Awake()
    {
        _homeRotation = transform.localRotation;
    }

    private void Update()
    {
        if (IsActiveCamera())
        {
            HandleInput();
        }

        ApplyRotation();
    }

    private bool IsActiveCamera()
    {
        return CameraSwitcher.Instance != null
            && CameraSwitcher.Instance.CurrentCamera == gameObject;
    }

    private void HandleInput()
    {
        if (!Input.GetMouseButton(_dragMouseButton))
        {
            return;
        }

        float deltaX = Input.GetAxisRaw("Mouse X") * _sensitivity;
        float deltaY = Input.GetAxisRaw("Mouse Y") * _sensitivity;

        if (_invertTilt)
        {
            deltaY = -deltaY;
        }

        _yaw = Mathf.Clamp(_yaw + deltaX, _minYaw, _maxYaw);
        _pitch = Mathf.Clamp(_pitch - deltaY, _minPitch, _maxPitch);
    }

    private void ApplyRotation()
    {
        Quaternion target = _homeRotation * Quaternion.Euler(_pitch, _yaw, 0f);

        if (_smoothing > 0f)
        {
            transform.localRotation = Quaternion.Slerp(
                transform.localRotation, target, _smoothing * Time.deltaTime);
        }
        else
        {
            transform.localRotation = target;
        }
    }
}