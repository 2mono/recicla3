using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGame : MonoBehaviour
{
    [SerializeField] private GameObject enterUI00, enterUI01, enterUI02;
    [SerializeField] private AudioClip warpEnter;

    

    private void Start()
    {
        enterUI00.SetActive(false);
        enterUI01.SetActive(false);
        enterUI02.SetActive(false);
    }
    public void Game00()
    {
        AudioSource.PlayClipAtPoint(warpEnter, transform.position);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enterUI00.SetActive(true);
    }
    public void Game01()
    {
        AudioSource.PlayClipAtPoint(warpEnter, transform.position);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enterUI01.SetActive(true);
    }    
    public void Game02()
    {
        AudioSource.PlayClipAtPoint(warpEnter, transform.position);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enterUI02.SetActive(true);
    }

    public void CloseUI00()
    {
        enterUI00.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CloseUI01()
    {
        enterUI01.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CloseUI02()
    {
        enterUI02.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
