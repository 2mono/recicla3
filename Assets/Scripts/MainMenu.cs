using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject optionsMenu;

    AudioSource audioSource;


    private void Start()
    {
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        backButton.SetActive(false);
        optionsMenu.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("main");
    }

    public void OptionsButton()
    {
        backButton.SetActive(true);
        optionsMenu.SetActive(true);
        startButton.SetActive(false);
        optionsButton.SetActive(false);
    }

    public void BackButton()
    {
        backButton.SetActive(false);
        optionsMenu.SetActive(false);
        startButton.SetActive(true);
        optionsButton.SetActive(true);
    }
}
