public class CustomerController
{
    private CustomerView _view;

    private CustomerState _state;

    public CustomerController(
        CustomerView view
    )
    {
        _view = view;
    }

    public void Initialize()
    {
        ChangeState(CustomerState.SPAWN);
    }

    private void ChangeState(CustomerState newState)
    {
        _state = newState;

        switch(_state)
        {
            case CustomerState.SPAWN:
            break;
            default:
            break;
        }
    }
}