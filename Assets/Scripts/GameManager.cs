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
    
    public Text messageUI;
    public Text items;
    public GameObject messagesGO;
    int itemType;
    int itemCount;
    GameObject player;
    bool winGame = false;

    public bool inQuestNene = false;
    public bool inQuestNeneFinished = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        messagesGO.SetActive(false);

        StartGame();
    }

    private void Update()
    {
        WinGame();
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

    public void GameType(int gameType)
    {
        switch (gameType)
        {
            //TODO
            case 0:
                //Latas
                break;
        }
    }

    public async void WinGame()
    {
        if (itemCount == 5)
        {
            winGame = true;
            MessageUI("Pasaste al siguiente nivel!");
            await Task.Delay(3000);
            //TODO

        }
    }



    public void StartGame()
    {
        messageUI.gameObject.SetActive(false);
        player = GameObject.Find("Recolectora");
        itemCount = 0;

        itemType = Random.Range(0, 2);
        switch (itemType)
        {
            case 0:
                MessageUI("Debes juntar 5 latas en menos de 2 minutos!");
                GameType(itemType);
                break;
            case 1:
                MessageUI("Debes juntar 5 botellas en menos de 2 minutos!");
                GameType(itemType);
                break;
            case 2:
                MessageUI("Debes juntar 5 vasos en menos de 2 minutos!");
                GameType(itemType);
                break;
        }

        DontDestroyOnLoad(gameObject);
    }

    public async void EndGame()
    {
        //TODO
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.GetComponent<Animator>().SetTrigger("EndGame");
        
        MessageUI("Fin del Juego :(");
        await Task.Delay(6000);
        SceneManager.LoadScene("main");
        winGame = false;
    }

    public void CountItem()
    {
        itemCount++;
        items.text = itemCount.ToString() + "/5";
    }


}
