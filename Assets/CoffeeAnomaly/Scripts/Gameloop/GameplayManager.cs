using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [Header("Order Manager")]
    [SerializeField] private OrderManager _orderManager;

    [Header("Customer")]
    [SerializeField] private CustomerView _customerMalePrefab;
    [SerializeField] private CustomerView _customerFemalePrefab;
    [SerializeField] private Transform _customerSpawnLocator;
    [SerializeField] private Transform[] _chairLocators;

    [Header("UI")]
    [SerializeField] private Button _spawnNewCustomer;
    [SerializeField] private Button _removeCustomer;
    [SerializeField] private Button _serve;
    [SerializeField] private Button _receiveOrder;
    [SerializeField] private Button _backToMenu;

    [Header("Customer Action")]
    [SerializeField] private Button _idle;
    [SerializeField] private Button _sitIdle;
    [SerializeField] private Button _gotoChair;

    private CustomerView _customer;
    private Order _order;

    private void Awake()
    {
        _spawnNewCustomer.onClick.AddListener(OnSpawnNewCustomer);
        _removeCustomer.onClick.AddListener(OnRemoveCustomer);
        _serve.onClick.AddListener(OnServeMenu);
        _receiveOrder.onClick.AddListener(OnReceiveOrder);
        _backToMenu.onClick.AddListener(OnBackToMenu);

        _idle.onClick.AddListener(OnIdle);
        _sitIdle.onClick.AddListener(OnSitIdle);
        _gotoChair.onClick.AddListener(OnGotoChair);
    }

#region UI Event
    private void OnSpawnNewCustomer()
    {
        if(_customer != null)
        {
            Debug.LogError("Customer spawned, Please remove customer and try to spawn again");
            return;
        }

        CustomerView customer = RandomCustomer();

        _customer = Instantiate(customer);
        _customer.SetPositionAndRotation(
            _customerSpawnLocator.position,
            _customerSpawnLocator.rotation
        );
    }

    private void OnRemoveCustomer()
    {
        if(_customer == null)
        {
            Debug.LogError("Doesn't have customer to remove.");
            return;
        }
        Destroy(_customer.gameObject);
    }

    private void OnServeMenu()
    {
        if(_order == null)
        {
            Debug.LogError("Currently has no order");
            return;
        }
        Debug.Log("serve : " + _order.Name);
        _order = null;
    }

    private void OnReceiveOrder()
    {
        _order = _orderManager.CreateOrder("Late");
        Debug.Log("Current order to make : " + _order.Name);
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
#endregion

#region Customer Animation Event
    private void OnIdle()
    {
        _customer.SetIdle();
    }

    private void OnSitIdle()
    {
        _customer.SetSitIdle();
    }

    private void OnGotoChair()
    {
        Transform target = RandomChair();
        _customer.SetPositionAndRotation(target.position, target.rotation);
    }
#endregion
    private CustomerView RandomCustomer()
    {
        CustomerView[] customerPrefabs = new CustomerView[]
        {
            _customerFemalePrefab,
            _customerMalePrefab
        };

        return customerPrefabs[RandomInt(0, customerPrefabs.Length)];
    }

    private Transform RandomChair()
    {
        return _chairLocators[RandomInt(0, _chairLocators.Length)];
    }

    private int RandomInt(int min, int max)
    {
        return Random.Range(min, max);
    }
}
