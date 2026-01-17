using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject CreditsPanel;

    [SerializeField] private AudioSource UIAudioSource;
    [SerializeField] private AudioClip Quack;


    public void Start()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
    }
    public void StartGame() 
    {
        PlayClick();
        SceneManager.LoadScene("Playground");
    }
    public void QuitGame() 
    {
        
        Application.Quit();
    }

    public void OpenCredits() 
    {
        PlayClick();
        if (CreditsPanel != null) 
        { CreditsPanel.SetActive(true);
            MainPanel.SetActive(false);
        }
    
    }

    public void CloseCredits() 
    {
        PlayClick();
        if (CreditsPanel != null)
        { CreditsPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
    }

    void PlayClick() 
    {
        if (UIAudioSource != null && Quack != null) { UIAudioSource.PlayOneShot(Quack); }
    }
  
        
   


}
