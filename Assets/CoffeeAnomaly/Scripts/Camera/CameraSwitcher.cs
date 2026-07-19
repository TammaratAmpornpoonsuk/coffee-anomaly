using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private GameObject[] _cameras;

    [Header("Button")]
    [SerializeField] private Button _camera1;
    [SerializeField] private Button _camera2;
    [SerializeField] private Button _camera3;
    [SerializeField] private Button _camera4;

    private GameObject _currentCamera;
    public GameObject CurrentCamera => _currentCamera;

    public static CameraSwitcher Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        
        _camera1.onClick.AddListener(() => SwitchTo(0));
        _camera2.onClick.AddListener(() => SwitchTo(1));
        _camera3.onClick.AddListener(() => SwitchTo(2));
        _camera4.onClick.AddListener(() => SwitchTo(3));

        SwitchTo(0);
    }

    private void SwitchTo(int index)
    {
        foreach(var cam in _cameras)
        {
            cam.SetActive(false);
        }
        _currentCamera = _cameras[index];
        _currentCamera.SetActive(true);
    }
}
