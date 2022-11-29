using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject enterUI0, enterUI1, enterUI2;

    public Text messageUI;

    public GameObject itemCountUI;
    public GameObject timeCountUI;

    public GameObject spawnResiduos;

    //TODO Menu de confirmacion si quiere entrar al minijuego
    
    public Text items;
    public GameObject messagesGO;
    
    
    int itemCount;
    
    public bool winGame00,winGame01,winGame02,winGame03 = false;

    public bool inQuestNene = false;
    public bool inQuestNeneFinished = false;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        messagesGO.SetActive(false);

        itemCountUI.SetActive(false);
        timeCountUI.SetActive(false);

        spawnResiduos.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public async void MessageUI(string message)
    {
        messagesGO.SetActive(true);
        messageUI.text = message;
        messageUI.gameObject.SetActive(true);
        await Task.Delay(5000);
        messageUI.gameObject.SetActive(false);
        messagesGO.SetActive(false);
    }

    public async void StartSubmarineGame()
    {
        MessageUI("Ayuda a nuestros amigos del agua, recolectando residuos!");
        await Task.Delay(3000);
        SceneManager.LoadScene("submarine_game");
    }

    public async void StartFPSGame()
    {
        MessageUI("Prueba tu punteria! Intenta vencer al retador 1!");
        await Task.Delay(3000);
        SceneManager.LoadScene("fps_game");
    }

    public void StartGameRecollect()
    {
        MessageUI("Recolecta los residuos que puedas en 2 minutos!");
        enterUI0.SetActive(false);
        spawnResiduos.SetActive(true);
        Timer.Instance.timerOn = true;
        itemCountUI.SetActive(true);
        timeCountUI.SetActive(true);
    }

    public async void EndFPSGame()
    {
        MessageUI("Recolectaste " + TargetBounds.Instance.targetCount + " descartables!");
        
        await Task.Delay(3000);

        MessageUI("Bien lo lograste!");
        SceneManager.LoadScene("main");
        winGame02 = true;
    }

    public async void EndGameRecollect()
    {
        //TODO Cuando termina, marca tacho como realizado y poder seguir con los otros
                       
        MessageUI("Recolectaste " + itemCount + " descartables!");
        await Task.Delay(3000);
        MessageUI("Bien lo lograste!");
        itemCountUI.SetActive(false);
        timeCountUI.SetActive(false);

        spawnResiduos.SetActive(false);

        winGame00 = true;
    }

    public void EndGameNinie()
    {
        MessageUI("Bien lo lograste!");
        winGame01 = true;
    }

    public void CountItem()
    {
        itemCount++;
        items.text = itemCount.ToString();
    }




}
