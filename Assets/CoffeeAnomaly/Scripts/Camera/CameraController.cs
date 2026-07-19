using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minPitch = -80f;
    [SerializeField] private float _maxPitch = 80f;

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Vector2 delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            if(delta.x != 0)
            {
                CameraSwitcher.Instance.CurrentCamera.transform.Rotate(0f, delta.x, 0f, Space.World);
            }
            if(delta.y != 0)
            {
                Vector3 euler = CameraSwitcher.Instance.CurrentCamera.transform.localEulerAngles;
                float pitch = NormalizeAngle(euler.x);
                pitch = Mathf.Clamp(pitch - delta.y, _minPitch, _maxPitch);

                CameraSwitcher.Instance.CurrentCamera.transform.localRotation = Quaternion.Euler(pitch, euler.y, euler.z);
            }
        }
    }

    private static float NormalizeAngle(float angle) {
        angle %= 360f;
        if(angle > 180f) angle -= 360f;
        return angle;
    }
}