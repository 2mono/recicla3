using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    bool on;
    bool inAnimation;

    void Start()
    {
        menu.SetActive(false);
        on = false;
    }
    void Update()
    {
        if (!on && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            menu.SetActive(true);
            on = true;
        }
        else if (on && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            menu.SetActive(false);
            on = false;
        }
    }
    
    public void Quit()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}