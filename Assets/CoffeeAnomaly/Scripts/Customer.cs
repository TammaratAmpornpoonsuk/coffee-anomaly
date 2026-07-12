using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private readonly int _idle = Animator.StringToHash("idle");
    private readonly int _sitIdle = Animator.StringToHash("sit-idle");

    public void SetIdle()
    {
        _animator.SetTrigger(_idle);
    }

    public void SetSitIdle()
    {
        _animator.SetTrigger(_sitIdle);
    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
    }
}
