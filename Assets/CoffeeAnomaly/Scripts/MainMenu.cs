using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button settingButton;
    [SerializeField]
    private Button quitButton;

    private void Awake()
    {
        newGameButton.onClick.AddListener(OnStartNewGame);
    }

    private void OnStartNewGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
