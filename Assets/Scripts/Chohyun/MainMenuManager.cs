using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject CreditsPanel;

    public void StartGame() 
    {
        SceneManager.LoadScene("Playground");
    }
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void OpenCredits() 
    {
        if (CreditsPanel != null) 
        { CreditsPanel.SetActive(true);
            MainPanel.SetActive(false);
        }
    
    }

    public void CloseCredits() 
    {
        if (CreditsPanel != null)
        { CreditsPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
    }


}
