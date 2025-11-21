using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pauseMenuCanvas;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShowOrHidePauseMenu();
        }
    }

    private void ShowOrHidePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResetMenu()
    {
        ShowOrHidePauseMenu();
    }
}
