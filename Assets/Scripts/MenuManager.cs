using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject settingsPanel;

    private bool isAnyPanelActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (menuPanel == null && settingsPanel == null)
        {
            return;
        }
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);         
    }

    public void Play()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Settings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseSettings()
    {
        menuPanel?.SetActive(true);
        settingsPanel?.SetActive(false);
    }

    private void ToggleMenu(InputAction.CallbackContext ctx)
    {
        Time.timeScale = !isAnyPanelActive ? 1 : 0;
        if (!isAnyPanelActive) 
        { 
            menuPanel.SetActive(true);
            isAnyPanelActive = true;
        }
        else
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            isAnyPanelActive = false;
        }
        
    }
}
