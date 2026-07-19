using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Order CreateOrder(string name)
    {
        return new Order(name);
    }
}
