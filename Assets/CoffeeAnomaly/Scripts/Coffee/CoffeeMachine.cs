using UnityEngine;

public class CoffeeMachine : MonoBehaviour, IClickable
{
    public void OnMouseDown()
    {
        Debug.Log("Make a coffee");
    }
}